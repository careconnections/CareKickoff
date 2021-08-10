import { Fab, makeStyles, Tooltip } from "@material-ui/core";
import { ClassNameMap } from "@material-ui/core/styles/withStyles";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";
import { NextRouter, useRouter } from "next/dist/client/router";
import { useSnackbar } from "notistack";
import { theme } from "../styles/theme";
import { defaultSnackbarOptions } from "../pages/defaultSnackbarOptions";

const useFabStyles = makeStyles({
	fab: {
		position: "absolute",
		bottom: theme.spacing(9),
		right: theme.spacing(8),
		backgroundColor: theme.palette.primary.main,
		color: theme.palette.getContrastText(theme.palette.primary.main),
	},
});

export const LogoutFab = () => {
	const router: NextRouter = useRouter();

	const classes = useFabStyles();

	const { enqueueSnackbar } = useSnackbar();

	const handleLogout: () => void = () => {
		window.sessionStorage.clear();

		fetch(`${process.env.API}/logout`, {
			method: "POST",
		})
			.then((response: Response) => response.json())
			.then((json: any) => {
				enqueueSnackbar(json.message, {
					...defaultSnackbarOptions,
					variant: "info",
				});
			})
			.catch((err) => console.log(err))
			.finally(() => router.push("/"));
	};

	return (
		<Tooltip title="Logout">
			<Fab className={classes.fab} onClick={handleLogout}>
				<ExitToAppIcon />
			</Fab>
		</Tooltip>
	);
};
