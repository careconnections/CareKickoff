import {
	Typography,
	List,
	ListItem,
	IconButton,
	ListItemAvatar,
	Avatar,
	ListItemText,
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
import { useState } from "react";
import { employees, clients, rapports, careplans as carePlans } from "./data";

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

	const [selectedCarePlan, setSelectedCarePlan] = useState<object>();

	const [open, setOpen] = useState(false);

	const showCarePlan = (id: string) => {
		const newLocal = carePlans.find((c) => c.Id === id);
		console.log(newLocal);
		if (newLocal) {
			setSelectedCarePlan(newLocal);
			setOpen(true);
		}
	};

	return (
		<div className={HomeStyle.container}>
			{selectedCarePlan && (
				<Modal
					aria-labelledby="transition-modal-title"
					aria-describedby="transition-modal-description"
					open={open}
					onClose={() => setOpen(false)}
					closeAfterTransition
					BackdropComponent={Backdrop}
					BackdropProps={{
						timeout: 500,
					}}
				>
					<Fade in={open}>
						<Paper>
							<Typography variant="h2" gutterBottom>
								{selectedCarePlan.DisplayName}
							</Typography>
							{selectedCarePlan.Goals.map((g, i) => {
								<Typography
									key={i}
									variant="body1"
									gutterBottom
								>
									{g.DisplayName}
								</Typography>;
							})}
						</Paper>
					</Fade>
				</Modal>
			)}
			<Head>
				<title>Care connections kick off</title>
				<meta name="description" content="Care connections kick off" />
				<link rel="icon" href="/favicon.ico" />
			</Head>

			<main className={HomeStyle.main}>
				<div
					style={{
						width: 960,
						height: "100%",
						display: "flex",
						flexDirection: "column",
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
						style={{ height: "100%" }}
					>
						<Grid item xs={3}>
							<Card
								elevation={4}
								style={{
									height: "100%",
								}}
							>
								<List dense className={ClientStyle.list}>
									{employeeClients.map((client, i) => (
										<ListItem
											key={i}
											divider
											button
											id={client.NativeId}
											onClick={() => {
												setSelectedClient(
													clients.find(
														(c) =>
															c.NativeId ===
															client.NativeId
													)
												);
												setClientRapports(
													rapports.filter(
														(r) =>
															r.ClientId ===
															client.NativeId
													)
												);
											}}
											selected={
												client.NativeId ===
												selectedClient.NativeId
											}
										>
											<ListItemAvatar>
												<Avatar color="primary">
													<PersonIcon />
												</Avatar>
											</ListItemAvatar>
											<ListItemText
												primary={`${client.FirstName} ${client.LastName}`}
												secondary={
													client.BirthDate.split(
														"T"
													)[0]
												}
											/>
										</ListItem>
									))}
								</List>
							</Card>
						</Grid>
						<Grid item xs={9}>
							<Card
								elevation={4}
								style={{
									height: "100%",
									padding: theme.spacing(4),
								}}
							>
								<Typography variant="h4" gutterBottom>
									{`${selectedClient.FirstName} ${selectedClient.LastName}  rapports`}
								</Typography>
								<Typography variant="subtitle1" gutterBottom>
									{`${
										selectedClient.Gender
									} - age ${CalculateAge(
										new Date(
											Date.parse(selectedClient.BirthDate)
										)
									)}`}
								</Typography>
								<List dense className={ClientStyle.list}>
									{clientRapports &&
										clientRapports.map((rapport, i) => (
											<div key={i}>
												<Typography
													variant="h6"
													gutterBottom
												>
													{rapport.Subject}
												</Typography>
												<Typography
													variant="subtitle2"
													gutterBottom
												>
													{
														new Date(
															Date.parse(
																rapport.CreatedAt
															)
														)
															.toISOString()
															.split("T")[0]
													}
												</Typography>
												<Typography
													variant="body1"
													gutterBottom
												>
													{
														carePlans.find(
															(c) =>
																c.Id ===
																rapport.CarePlanGoalId
														)?.DisplayName
													}
												</Typography>
												<Button
													onClick={() =>
														showCarePlan(
															rapport.CarePlanGoalId
														)
													}
												>
													Info
												</Button>
												<Divider />
											</div>
										))}
								</List>
							</Card>
						</Grid>
					</Grid>
				</div>
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
