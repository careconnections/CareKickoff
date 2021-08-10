import { makeStyles } from "@material-ui/core";
import { theme } from "../styles/theme";

const useReportListStyles = makeStyles({
	errorIcon: {
		position: "absolute",
		top: 0,
		right: 0,
		margin: theme.spacing(1),
		fill: "red",
	},
	listItem: {
		alignItems: "flex-start",
		flexDirection: "column",
		width: " 100%",
		maxWidth: " 480px",
	},
});
export { useReportListStyles };
