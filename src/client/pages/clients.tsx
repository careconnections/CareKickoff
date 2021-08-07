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

export default function Home() {
	return (
		<div className={styles.container}>
			<Head>
				<title>Care connections kick off</title>
				<meta name="description" content="Care connections kick off" />
				<link rel="icon" href="/favicon.ico" />
			</Head>

			<main className={styles.main}>
				<Typography variant="h1" gutterBottom>
					Clients
				</Typography>
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
