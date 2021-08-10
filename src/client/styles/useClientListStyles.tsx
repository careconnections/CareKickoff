import { makeStyles } from "@material-ui/core";
import { theme } from "./theme";

export const useClientListStyles = makeStyles({
	list: {
		overflowY: "auto",
		height: "100%",
		padding: 0,
	},
	avatar: {
		color: theme.palette.getContrastText(theme.palette.primary.main),
		backgroundColor: theme.palette.primary.main,
	},
});
