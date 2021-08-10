import { makeStyles } from "@material-ui/core";
import { theme } from ".";

export const usePortalStyles = makeStyles({
	overflowFlex: {
		flex: " 1 0 auto",
		minHeight: 0,
		height: "100%",
		overflowX: "hidden",
		overflowY: "auto",
		margin: `${theme.spacing(2)}px 0px`,
		width: "100%",
	},
	main: {
		minHeight: 0,
		overflow: "hidden",
		width: 960,
		height: "100vh",
		flexDirection: "column",
		paddingLeft: 10,
		paddingRight: 10,
		paddingBottom: 0,
		alignItems: "flex-start",
	},
	viewGridContainer: {
		minHeight: 0,
		marginBottom: theme.spacing(2),
		flex: "1 1 auto",
	},
});
