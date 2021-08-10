import { makeStyles } from "@material-ui/core";
import { theme } from "../styles/theme";

export const useFabStyles = makeStyles({
	fab: {
		position: "absolute",
		bottom: theme.spacing(9),
		right: theme.spacing(8),
		backgroundColor: theme.palette.primary.main,
		color: theme.palette.getContrastText(theme.palette.primary.main),
	},
});
