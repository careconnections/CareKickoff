import { OptionsObject } from "notistack";

export const defaultSnackbarOptions: OptionsObject = {
	variant: "error",
	preventDuplicate: true,
	anchorOrigin: {
		vertical: "bottom",
		horizontal: "center",
	},
};
