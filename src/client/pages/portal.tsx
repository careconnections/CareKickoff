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

const employees = [
	{ Name: "Sander", EmployeeId: "1", AuthorizedClients: ["1", "2", "4"] },
	{ Name: "Peter", EmployeeId: "2", AuthorizedClients: ["2", "3"] },
	{ Name: "Chris", EmployeeId: "3", AuthorizedClients: ["3", "4", "5"] },
];

const clients = [
	{
		FirstName: "Paul",
		LastName: "Driver",
		BirthDate: "1980-05-20T00:00:00",
		Gender: "male",
		NativeId: "1",
	},
	{
		FirstName: "Scarlet",
		LastName: "Jonahson",
		BirthDate: "1985-01-11T00:00:00",
		Gender: "female",
		NativeId: "2",
	},
	{
		FirstName: "Jessica",
		LastName: "Albo",
		BirthDate: "1982-04-11T00:00:00",
		Gender: "female",
		NativeId: "3",
	},
	{
		FirstName: "Jwayne",
		LastName: "Dohnson",
		BirthDate: "1972-12-30T00:00:00",
		Gender: "male",
		NativeId: "4",
	},
	{
		FirstName: "Prad",
		LastName: "Bitt",
		BirthDate: "1940-05-20T00:00:00",
		Gender: "male",
		NativeId: "5",
	},
];

const rapports = [
	{
		Subject: "High bloodpressure",
		Text: "Client seems to have excessive lifestyle, causing high bloodpressure. Adviced to stop driving so fast.",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "1",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-12T15:22:00",
	},
	{
		Subject: "Short attention span",
		Text: "Client only pays attention for 9.8 seconds",
		HasPriority: false,
		CarePlanGoalId: "2",
		ClientId: "1",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-11T14:00:00",
	},
	{
		Subject: "Burn marks",
		Text: "Mr. Driver burnt his hand cooking dinner.",
		HasPriority: true,
		CarePlanGoalId: "",
		ClientId: "1",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-10T08:40:00",
	},
	{
		Subject: "Trouble walking",
		Text: "Ms. Jonahson has trouble walking for more than a few minutes at a time",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "2",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-12T15:00:00",
	},
	{
		Subject: "Random language loss",
		Text: "Client sometimes seems lost trying to translate her words, and she can only speak Japanese for a few minutes",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "2",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-11T12:00:00",
	},
	{
		Subject: "Quiet day",
		Text: "Everything went well today",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "2",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-08T17:30:00",
	},
	{
		Subject: "Quiet day",
		Text: "Nothing special happened",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "3",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-12T16:50:00",
	},
	{
		Subject: "Physical exercise",
		Text: "Client tried surfing today to regain mobility, went well",
		HasPriority: false,
		CarePlanGoalId: "1",
		ClientId: "3",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-11T15:00:00",
	},
	{
		Subject: "Sprained ankle",
		Text: "Ms. Albo sprained her ankle",
		HasPriority: false,
		CarePlanGoalId: "1",
		ClientId: "3",
		CreatedBy: "Chris",
		CreatedAt: "2019-08-04T11:19:00",
	},
	{
		Subject: "Too much protein",
		Text: "Mr. Dohnson exceeded his agreed limit of maximum 5 protein shakes a day",
		HasPriority: false,
		CarePlanGoalId: "1",
		ClientId: "4",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-12T15:22:00",
	},
	{
		Subject: "Couldn't get out of bed",
		Text: "Client refused to get up and stayed in bed all day",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "4",
		CreatedBy: "Remco",
		CreatedAt: "2019-08-10T22:45:00",
	},
];

const careplans = [
	{
		Id: "1",
		DisplayName: "Careplan Paul Driver, 2019",
		ClientId: "1",
		Goals: [
			{ DisplayName: "Drive slower", GoalId: "1" },
			{ DisplayName: "Work on focus", GoalId: "2" },
		],
	},
	{
		Id: "1",
		DisplayName: "Careplan",
		ClientId: "2",
		Goals: [
			{ DisplayName: "Get back sense of direction", GoalId: "1" },
			{ DisplayName: "Sleep enough", GoalId: "2" },
			{ DisplayName: "Learn new languages", GoalId: "2" },
		],
	},
	{
		Id: "2",
		DisplayName: "Omaha plan",
		ClientId: "2",
		Goals: [{ DisplayName: "Bring more structure in life", GoalId: "1" }],
	},
	{
		Id: "1",
		DisplayName: "Careplan",
		ClientId: "3",
		Goals: [{ DisplayName: "Exercise enough", GoalId: "1" }],
	},
	{
		Id: "1",
		DisplayName: "Careplan",
		ClientId: "4",
		Goals: [{ DisplayName: "Limit amount of food", GoalId: "1" }],
	},
	{
		Id: "2",
		DisplayName: "Careplan 2019",
		ClientId: "5",
		Goals: [
			{ DisplayName: "Style hair every morning", GoalId: "1" },
			{ DisplayName: "Contact mother weekly", GoalId: "2" },
		],
	},
	{
		Id: "1",
		DisplayName: "Careplan 2018",
		ClientId: "5",
		Goals: [
			{ DisplayName: "Style hair every morning", GoalId: "1" },
			{ DisplayName: "Contact mother weekly", GoalId: "2" },
		],
	},
];

export default function Portal() {
	const router = useRouter();

	const toClient = () => router.push("/client");

	// const { isLoading, data } = useFetch("http://localhost:3001/employee");

	const employee = employees.find((e) => e.Name === "Sander");

	const employeeClients = clients.filter((c) =>
		employee?.AuthorizedClients.includes(c.NativeId)
	);

	const selectedClient = employeeClients[0];

	const clientRapports = rapports.filter(
		(r) => r.ClientId === selectedClient.NativeId
	);

	const [open, setOpen] = useState(false);

	console.log(employeeClients);

	const showCarePlan = (id: string) => {
		setOpen(true);
	};

	return (
		<div className={HomeStyle.container}>
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
						<h2 id="transition-modal-title">Transition modal</h2>
						<p id="transition-modal-description">
							react-transition-group animates me.
						</p>
					</Paper>
				</Fade>
			</Modal>
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
										<ListItem key={i} divider button>
											<ListItemAvatar>
												<Avatar color="primary">
													<PersonIcon />
												</Avatar>
											</ListItemAvatar>
											<ListItemText
												primary={`${client.FirstName} ${client.LastName}`}
												secondary={
													new Date(
														Date.parse(
															client.BirthDate
														)
													)
														.toISOString()
														.split("T")[0]
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
									} - age ${_calculateAge(
										new Date(
											Date.parse(selectedClient.BirthDate)
										)
									)}`}
								</Typography>
								<List dense className={ClientStyle.list}>
									{clientRapports.map((rapport, i) => (
										<>
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
													careplans.find(
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
										</>
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

function _calculateAge(birthday) {
	// birthday is a date
	var ageDifMs = Date.now() - birthday.getTime();
	var ageDate = new Date(ageDifMs); // miliseconds from epoch
	return Math.abs(ageDate.getUTCFullYear() - 1970);
}
