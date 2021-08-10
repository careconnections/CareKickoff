import { Typography, Grid, Divider } from "@material-ui/core";
import { FunctionComponent } from "react";
import { Client } from "./Types";
import { CalculateAge } from "./Utilities";

const ClientHeader: FunctionComponent<{ client: Client | undefined }> = ({
	client,
}) => (
	<>
		{client && (
			<>
				<Grid item>
					<Typography variant="h4" gutterBottom>
						{`${client.FirstName} ${client.LastName}'s info`}
					</Typography>
				</Grid>
				<Grid item>
					<Typography variant="subtitle1" gutterBottom>
						{`${client.Gender} - age ${CalculateAge(
							new Date(Date.parse(client.BirthDate))
						)}`}
					</Typography>
					<Divider />
				</Grid>
			</>
		)}
	</>
);

export { ClientHeader };
