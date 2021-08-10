import { Typography, Card, Grid, makeStyles } from "@material-ui/core";
import HomeStyle from "../styles/Home.module.css";
import { theme } from "../styles/theme";
import { useState } from "react";
import { useEffect } from "react";
import { ClientList } from "./ClientList";
import { CarePlan, Client, Employee, Report } from "./Types";
import { LogoutFab } from "../components";
import { Footer } from "./Footer";
import { Head } from "./Head";
import { ClientHeader } from "./ClientHeader";
import { ReportsList } from "./ReportsList";
import { CarePlansList } from "./CarePlansList";

const usePortalStyles = makeStyles({
	overflowFlex: {
		flex: " 1 0 auto",
		minHeight: 0,
		height: "100%",
		overflowX: "hidden",
		overflowY: "auto",
		margin: `${theme.spacing(2)}px 0px`,
		width: "100%",
	},
});

export default function Portal() {
	const classes = usePortalStyles();

	const [employee, setEmployee] = useState<Employee>();
	useEffect(() => {
		fetch(
			`${process.env.API}/employee/${window.sessionStorage.getItem("id")}`
		)
			.then((response: Response): Promise<Employee> => response.json())
			.then((employee: Employee) => setEmployee(employee))
			.catch((err: TypeError) => console.log(err));
	}, []);

	const [employeeClients, setEmployeeClients] = useState<Array<Client>>();
	useEffect(() => {
		if (!employee) return;

		console.log(employee);

		fetch(
			`${process.env.API}/clients/${JSON.stringify(
				employee.AuthorizedClients
			)}`
		)
			.then(
				(response: Response): Promise<Array<Client>> => response.json()
			)
			.then((clients: Array<Client>) => setEmployeeClients(clients))
			.catch((err: TypeError) => console.log(err));
	}, [employee]);

	const [selectedClient, setSelectedClient] = useState<Client>();

	const [clientReports, setClientReports] = useState<Array<Report>>();

	const [selectedCarePlans, setSelectedCarePlans] =
		useState<Array<CarePlan>>();

	useEffect(() => {
		if (!selectedClient) return;

		fetch(`${process.env.API}/reports/${selectedClient.NativeId}`)
			.then(
				(response: Response): Promise<Array<Report>> => response.json()
			)
			.then((clients: Array<Report>) => {
				console.log(clients);
				setClientReports(clients);
			})
			.catch((err: TypeError) => console.log(err));

		fetch(`${process.env.API}/careplans/${selectedClient.NativeId}`)
			.then(
				(response: Response): Promise<Array<CarePlan>> =>
					response.json()
			)
			.then((clients: Array<CarePlan>) => {
				console.log(clients);
				setSelectedCarePlans(clients);
			})
			.catch((err: TypeError) => console.log(err));
	}, [selectedClient]);

	return (
		<div className={HomeStyle.container}>
			<Head />

			<main
				className={HomeStyle.main}
				style={{
					minHeight: 0,
					overflow: "hidden",
					width: 960,
					height: "100vh",
					flexDirection: "column",
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
					{`${employee?.Name}'s clients`}
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
						<Card elevation={4}>
							{employeeClients ? (
								<ClientList
									employeeClients={employeeClients}
									onChange={(clientId: string) => {
										setSelectedClient(() =>
											employeeClients.find(
												(client: Client) =>
													client.NativeId === clientId
											)
										);
									}}
								/>
							) : (
								<Typography variant="body1">
									No clients
								</Typography>
							)}
						</Card>
					</Grid>
					<Grid
						item
						xs={9}
						style={{ display: "flex", maxHeight: "100%" }}
					>
						<Card
							elevation={4}
							style={{ padding: theme.spacing(4), width: "100%" }}
						>
							<Grid
								container
								direction="column"
								style={{
									minHeight: 0,
									flex: "0 1 100%",
									height: "100%",
									flexWrap: "nowrap",
								}}
							>
								{selectedClient && (
									<ClientHeader client={selectedClient} />
								)}
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
										direction="column"
										justifyContent="space-between"
										alignItems="flex-start"
										style={{ gap: theme.spacing(2) }}
									>
										<Grid
											item
											xs={6}
											className={classes.overflowFlex}
										>
											<Typography
												variant="h5"
												gutterBottom
											>
												Reports
											</Typography>
											<ReportsList
												clientReports={clientReports}
											/>
										</Grid>
										<Grid
											item
											xs={6}
											className={classes.overflowFlex}
										>
											<Typography
												variant="h5"
												gutterBottom
											>
												Care Plans
											</Typography>
											<CarePlansList
												selectedCarePlans={
													selectedCarePlans
												}
											/>
										</Grid>
									</Grid>
								</Grid>
							</Grid>
						</Card>
					</Grid>
				</Grid>
				<LogoutFab />
			</main>
			<Footer />
		</div>
	);
}
