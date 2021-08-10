import {
	Typography,
	Card,
	Box,
	CardContent,
	CardActions,
	Grid,
	TextField,
	Button,
} from "@material-ui/core";
import { useRouter } from "next/dist/client/router";
import { FormEvent } from "react";
import styles from "../styles/Home.module.css";
import { useSnackbar } from "notistack";
import { defaultSnackbarOptions } from "./defaultSnackbarOptions";
import { Footer } from "./Footer";
import { Head } from "./Head";
import { LoginData } from "./Types";

export default function Home() {
	const router = useRouter();

	const { enqueueSnackbar } = useSnackbar();

	const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();

		const username: string = e.currentTarget.username.value;

		const request: RequestInit = {
			method: "POST",
			body: JSON.stringify({ username }),
		};
		console.log(process.env.API);
		await fetch(`${process.env.API}/login`, request)
			.then((response: Response): Promise<LoginData> => response.json())
			.then((json: LoginData) => {
				window.sessionStorage.setItem("id", json.id);

				enqueueSnackbar(json.message, {
					...defaultSnackbarOptions,
					variant: "info",
				});

				router.push("/Portal");
			})
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
							<form onSubmit={onSubmit} method="post">
								<Grid
									container
									spacing={2}
									justifyContent="flex-end"
								>
									<Grid item xs={12}>
										<TextField
											fullWidth
											id="filled-basic"
											label="Employee name"
											name="username"
											variant="filled"
											color="secondary"
										/>
									</Grid>
									<Grid item>
										<Button
											variant="contained"
											color="primary"
											type="submit"
										>
											Sign in
										</Button>
									</Grid>
								</Grid>
							</form>
						</CardActions>
					</Box>
				</Card>
			</main>
			<Footer />
		</div>
	);
}
