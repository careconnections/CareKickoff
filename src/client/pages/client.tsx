import {
	Typography,
	List,
	ListItem,
	IconButton,
	ListItemAvatar,
	Avatar,
	ListItemText,
	ListItemSecondaryAction,
} from "@material-ui/core";
import NavigateNextIcon from "@material-ui/icons/NavigateNext";
import PersonIcon from "@material-ui/icons/Person";
import { useRouter } from "next/dist/client/router";
import Head from "next/head";
import Image from "next/image";
import HomeStyle from "../styles/Home.module.css";
import ClientStyle from "../styles/Clients.module.css";
import { theme } from "../styles/theme";
import useFetch from "react-fetch-hook";

export default function Client() {
	const router = useRouter();

	const toClient = () => router.push("/client");

	/* 	const { isLoading, data: clientsData } = useFetch(
		"http://localhost:3001/clients"
	); */

	return (
		<div className={HomeStyle.container}>
			<Head>
				<title>Care connections kick off</title>
				<meta name="description" content="Care connections kick off" />
				<link rel="icon" href="/favicon.ico" />
			</Head>

			<main className={HomeStyle.main}>
				<Typography variant="h1" gutterBottom>
					Clients
				</Typography>
				<List
					dense
					className={ClientStyle.list}
					style={{ backgroundColor: theme.palette.primary.light }}
				>
					{isLoading &&
						clientsData.map((object, i) => (
							<ListItem key={i}>
								<ListItemAvatar>
									<Avatar color="primary">
										<PersonIcon />
									</Avatar>
								</ListItemAvatar>
								<ListItemText
									primary={object.primary}
									secondary={object.secondary}
								/>
								<ListItemSecondaryAction>
									<IconButton
										color="secondary"
										edge="end"
										aria-label="delete"
										onClick={toClient}
									>
										<NavigateNextIcon />
									</IconButton>
								</ListItemSecondaryAction>
							</ListItem>
						))}
				</List>
			</main>

			<footer className={HomeStyle.footer}>
				<a
					href="https://vercel.com?utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
					target="_blank"
					rel="noopener noreferrer"
				>
					Powered by{" "}
					<span className={HomeStyle.logo}>
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
