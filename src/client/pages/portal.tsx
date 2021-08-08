import {
	Typography,
	List,
	ListItem,
	IconButton,
	ListItemSecondaryAction,
	Card,
	CardActions,
	CardContent,
	Grid,
	Box,
	Divider,
	Button,
	Modal,
	Fade,
	Backdrop,
	Paper,
	Fab,
	Tooltip,
} from "@material-ui/core";
import NavigateNextIcon from "@material-ui/icons/NavigateNext";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";
import ErrorIcon from "@material-ui/icons/Error";
import { useRouter } from "next/dist/client/router";
import Head from "next/head";
import Image from "next/image";
import HomeStyle from "../styles/Home.module.css";
import ClientStyle from "../styles/Clients.module.css";
import { theme } from "../styles/theme";
import useFetch from "react-fetch-hook";
import { useState } from "react";
import { employees, clients, rapports, careplans } from "./data";
import { useEffect } from "react";
import { ClientList } from "./ClientList";

export default function Portal() {
	const router = useRouter();

	const toClient = () => router.push("/client");

	// const { isLoading, data } = useFetch("http://localhost:3001/employee");

	const employee = employees.find((e) => e.Name === "Sander");

	const employeeClients = clients.filter((c) =>
		employee?.AuthorizedClients.includes(c.NativeId)
	);

	const [clientRapports, setClientRapports] = useState<object>();

	const [selectedClient, setSelectedClient] = useState<object>(() => {
		setClientRapports(
			rapports.filter((r) => r.ClientId === employeeClients[0].NativeId)
		);
		return employeeClients[0];
	});

	const [selectedCarePlans, setSelectedCarePlans] = useState<Array<object>>();

	useEffect(() => {
		if (!clientRapports) return;

		const clientCarePlans = careplans.filter(
			(c) => c.ClientId === selectedClient.NativeId
		);

		setSelectedCarePlans(clientCarePlans);
	}, [clientRapports, selectedClient]);

	return (
		<div className={HomeStyle.container}>
			<Head>
				<title>Care connections kick off</title>
				<meta name="description" content="Care connections kick off" />
				<link rel="icon" href="/favicon.ico" />
			</Head>

			<main
				className={HomeStyle.main}
				style={{
					minHeight: 0,
					overflow: "hidden",
					width: 960,
					height: "100vh",
					flexDirection: "column",
					alignItems: "center",
					paddingLeft: 10,
					paddingRight: 10,
					paddingBottom: 0,
					alignItems: "flex-start",
				}}
			>
				<Typography variant="h1" gutterBottom>
					Portal
				</Typography>
				<Typography variant="h3" gutterBottom>
					{`${employee.Name}'s clients`}
				</Typography>
				<Grid
					container
					spacing={4}
					direction="row"
					justifyContent="center"
					alignItems="stretch"
					style={{
						minHeight: 0,
						marginBottom: theme.spacing(2),
						flex: "1 1 auto",
					}}
				>
					<Grid
						item
						xs={3}
						style={{ display: "flex", maxHeight: "100%" }}
					>
						<ClientList
							employeeClients={employeeClients}
							setSelectedClient={setSelectedClient}
							setClientRapports={setClientRapports}
							selectedClient={selectedClient}
						/>
					</Grid>
					<Grid
						item
						xs={9}
						style={{ display: "flex", maxHeight: "100%" }}
					>
						<Card
							elevation={4}
							style={{ padding: theme.spacing(4) }}
						>
							<Grid
								container
								direction="column"
								style={{
									minHeight: 0,
									flex: "0 1 100%",
									height: "100%",
									flexWrap: "noWrap",
								}}
							>
								<Grid item>
									<Typography variant="h4" gutterBottom>
										{`${selectedClient.FirstName} ${selectedClient.LastName}'s info`}
									</Typography>
								</Grid>
								<Grid item>
									<Typography
										variant="subtitle1"
										gutterBottom
									>
										{`${
											selectedClient.Gender
										} - age ${CalculateAge(
											new Date(
												Date.parse(
													selectedClient.BirthDate
												)
											)
										)}`}
									</Typography>
									<Divider />
								</Grid>
								<Grid
									item
									style={{
										minHeight: 0,
										flex: "0 1 auto",
										display: "flex",
										height: "100%",
									}}
								>
									<Grid
										container
										direction="row"
										justifyContent="space-between"
										alignItems="flex-start"
										style={{ gap: theme.spacing(2) }}
									>
										<Grid
											item
											xs={6}
											style={{
												flex: " 1 0 auto",
												minHeight: 0,
												height: "100%",
												overflowX: "hidden",
												overflowY: "auto",
												margin: `${theme.spacing(
													2
												)}px 0px`,
											}}
										>
											<Typography
												variant="h5"
												gutterBottom
											>
												Rapports
											</Typography>
											<List
												dense
												className={ClientStyle.list}
												style={{ maxWidth: "100%" }}
											>
												{clientRapports &&
													clientRapports.map(
														(rapport, i) => (
															<ListItem
																key={i}
																divider
																style={{
																	alignItems:
																		"flex-start",
																	flexDirection:
																		"column",
																}}
															>
																{rapport.HasPriority && (
																	<ErrorIcon
																		style={{
																			position:
																				"absolute",
																			top: 0,
																			right: 0,
																			margin: theme.spacing(
																				1
																			),
																			fill: "red",
																		}}
																	/>
																)}
																<Typography variant="h6">
																	{
																		rapport.Subject
																	}
																</Typography>
																<Typography
																	variant="subtitle2"
																	gutterBottom
																>
																	{`Created by ${
																		rapport.CreatedBy
																	} on ${
																		rapport.CreatedAt.split(
																			"T"
																		)[0]
																	}`}
																</Typography>
																<Typography
																	variant="body1"
																	gutterBottom
																>
																	{
																		rapport.Text
																	}
																</Typography>
															</ListItem>
														)
													)}
											</List>
										</Grid>
										<Grid
											item
											xs={6}
											style={{
												flex: " 1 0 auto",
												minHeight: 0,
												height: "100%",
												overflowX: "hidden",
												overflowY: "auto",
												margin: `${theme.spacing(
													2
												)}px 0px`,
											}}
										>
											<Typography
												variant="h5"
												gutterBottom
											>
												Care Plans
											</Typography>
											<List>
												{selectedCarePlans?.map(
													(c, i) => (
														<ListItem
															alignItems="flex-start"
															key={i}
															style={{
																flexDirection:
																	"column",
															}}
															divider={
																selectedCarePlans.length >
																1
															}
														>
															<Typography
																variant="h6"
																gutterBottom
															>
																{c.DisplayName}
															</Typography>
															<List dense>
																<Typography
																	variant="body1"
																	gutterBottom
																>
																	Goals
																</Typography>
																{c.Goals.map(
																	(g, i) => (
																		<ListItem
																			key={
																				i
																			}
																			disableGutters
																		>
																			<Typography variant="body2">
																				{
																					g.DisplayName
																				}
																			</Typography>
																		</ListItem>
																	)
																)}
															</List>
														</ListItem>
													)
												)}
											</List>
										</Grid>
									</Grid>
								</Grid>
							</Grid>
						</Card>
					</Grid>
				</Grid>
				<Tooltip title="Logout">
					<Fab
						style={{
							position: "absolute",
							bottom: theme.spacing(9),
							right: theme.spacing(8),
							backgroundColor: theme.palette.primary.main,
							color: theme.palette.getContrastText(
								theme.palette.primary.main
							),
						}}
						onClick={() => router.push("/")}
					>
						<ExitToAppIcon />
					</Fab>
				</Tooltip>
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

const CalculateAge = (birthday: Date): number => {
	let ageInMilliseconds = Date.now() - birthday.getTime();
	let ageAsDate = new Date(ageInMilliseconds);
	return Math.abs(ageAsDate.getUTCFullYear() - 1970);
};
