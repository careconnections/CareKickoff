import { Typography, List, ListItem } from "@material-ui/core";
import ErrorIcon from "@material-ui/icons/Error";
import ClientStyle from "../styles/Clients.module.css";
import { theme } from "../styles/theme";
import { FunctionComponent } from "react";
import { Report } from "./Types";

export const ReportsList: FunctionComponent<{
	clientReports: Array<Report> | undefined;
}> = ({ clientReports }) => {
	return (
		<List dense className={ClientStyle.list} style={{ maxWidth: "100%" }}>
			{clientReports &&
				clientReports.map((report: Report, i: number) => (
					<ListItem
						key={i}
						divider
						style={{
							alignItems: "flex-start",
							flexDirection: "column",
						}}
					>
						{report.HasPriority && (
							<ErrorIcon
								style={{
									position: "absolute",
									top: 0,
									right: 0,
									margin: theme.spacing(1),
									fill: "red",
								}}
							/>
						)}
						<Typography variant="h6">{report.Subject}</Typography>
						<Typography variant="subtitle2" gutterBottom>
							{`Created by ${report.CreatedBy} on ${
								report.CreatedAt.split("T")[0]
							}`}
						</Typography>
						<Typography variant="body1" gutterBottom>
							{report.Text}
						</Typography>
					</ListItem>
				))}
		</List>
	);
};
