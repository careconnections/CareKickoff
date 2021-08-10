import { Fab, Tooltip } from "@material-ui/core";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";
import { NextRouter, useRouter } from "next/dist/client/router";
import { useSnackbar } from "notistack";
import { defaultSnackbarOptions } from "../src/DefaultSnackbarOptions";
import { useFabStyles } from "../styles";

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
