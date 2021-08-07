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
import Head from "next/head";
import Image from "next/image";
import { FormEvent } from "react";
import styles from "../styles/Home.module.css";
import { useSnackbar } from "notistack";
import { defaultSnackbarOptions } from "./defaultSnackbarOptions";

export default function Home() {
	const router = useRouter();

	const { enqueueSnackbar } = useSnackbar();

	const onSubmit = async (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();

		const username: string = e.currentTarget.username.value;

		const headers: Headers = new Headers({
			Authorization:
				"Basic " +
				Buffer.from(`${username}:password`).toString("base64"),
		});

		const request: RequestInit = {
			method: "GET",
			headers,
		};

		const HandleLogin = (response: Response): void => {
			if (response.ok) {
				router.push("/clients");
			} else {
				if (username)
					enqueueSnackbar(`Employee  ${username}  does not exist`, {
						...defaultSnackbarOptions,
						variant: "error",
					});
				else
					enqueueSnackbar(`Please enter a employee name`, {
						...defaultSnackbarOptions,
						variant: "warning",
					});
			}
		};

		await fetch("http://localhost:3001/", request)
			.then(HandleLogin)
			.catch((err) => {
				enqueueSnackbar(err.message, {
					...defaultSnackbarOptions,
					variant: "error",
				});
			});
	};

	return (
		<div className={styles.container}>
			<Head>
				<title>Care connections kick off</title>
				<meta name="description" content="Care connections kick off" />
				<link rel="icon" href="/favicon.ico" />
			</Head>

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

			<footer className={styles.footer}>
				<a
					href="https://vercel.com?utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
					target="_blank"
					rel="noopener noreferrer"
				>
					Powered by{" "}
					<span className={styles.logo}>
						<Image
							src="/vercel.svg"
							alt="Vercel Logo"
							width={72}
							height={16}
						/>
					</span>
				</a>
			</footer>
		</div>
	);
}
