import {
	Typography,
	Card,
	Box,
	CardContent,
	CardActions,
} from "@material-ui/core";
import { useRouter } from "next/dist/client/router";
import { FormEvent } from "react";
import styles from "../styles/Home.module.css";
import { useSnackbar } from "notistack";
import { defaultSnackbarOptions } from "../src/DefaultSnackbarOptions";
import { Footer } from "../components/Footer";
import { Head } from "../components/Head";
import { LoginData } from "../types/LoginData";
import { LoginForm } from "../components";

export default function Home() {
	const router = useRouter();

	const { enqueueSnackbar } = useSnackbar();

	const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();

		const username: string = e.currentTarget.username.value;

		await fetch(`${process.env.API}/login`, {
			method: "POST",
			body: JSON.stringify({ username }),
		})
			.then(
				(response: Response): Promise<void> =>
					response.json().then((json: LoginData) => {
						enqueueSnackbar(json.message, {
							...defaultSnackbarOptions,
							variant: "info",
						});

						if (response.ok) {
							window.sessionStorage.setItem("id", json.id);
							router.push("/Portal");
						}
					})
			)
			.catch((err) => {
				enqueueSnackbar(err.message, {
					...defaultSnackbarOptions,
					variant: "error",
				});
			});
	};

	return (
		<div className={styles.container}>
			<Head />

			<main className={styles.main}>
				<Typography variant="h1" gutterBottom>
					Company
				</Typography>
				<Card>
					<Box>
						<CardContent>
							<Typography
								variant="h6"
								color="primary"
								gutterBottom
							>
								Login as employee
							</Typography>
						</CardContent>
						<CardActions>
							<LoginForm onSubmit={onSubmit} />
						</CardActions>
					</Box>
				</Card>
			</main>
			<Footer />
		</div>
	);
}
