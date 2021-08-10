import { Typography, List, ListItem } from "@material-ui/core";
import ErrorIcon from "@material-ui/icons/Error";
import { FunctionComponent } from "react";
import { Report } from "../types/Report";
import { useReportListStyles } from "../styles";

export const ReportsList: FunctionComponent<{
	clientReports: Array<Report> | undefined;
}> = ({ clientReports }) => {
	const classes = useReportListStyles();

	return (
		<List dense className={classes.listItem}>
			{clientReports &&
				clientReports.map((report: Report, i: number) => (
					<ListItem key={i} divider className={classes.listItem}>
						{report.HasPriority && (
							<ErrorIcon className={classes.errorIcon} />
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
