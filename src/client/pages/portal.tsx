import { Typography, Card, Grid } from "@material-ui/core";
import HomeStyle from "../styles/Home.module.css";
import { theme, usePortalStyles } from "../styles";
import { useState } from "react";
import { Client } from "../types";
import {
	LogoutFab,
	Footer,
	Head,
	ClientHeader,
	ReportsList,
	CarePlansList,
	ClientList,
} from "../components";
import { useReports, useEmployee, useClients, useCarePlans } from "../hooks";

export default function Portal() {
	const classes = usePortalStyles();

	const [selectedClient, setSelectedClient] = useState<Client>();

	const [employee] = useEmployee(window.sessionStorage.getItem("id"));

	const [employeeClients] = useClients(employee);

	const [clientReports] = useReports(selectedClient);

	const [selectedCarePlans] = useCarePlans(selectedClient);

	return (
		<div className={HomeStyle.container}>
			<Head />

			<main className={`${HomeStyle.main} ${classes.main}`}>
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
					className={classes.viewGridContainer}
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
