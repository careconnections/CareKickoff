import { createTheme } from "@material-ui/core/styles";

export const theme = createTheme({
	palette: {
		type: "light",
		primary: {
			main: "#00AEEF",
			light: "#66e0ff",
			dark: "#007fbc",
			contrastText: "#fff",
		},
		secondary: {
			main: "#FBB03D",
			light: "#ffe26e",
			dark: "#c48100",
			contrastText: "#fff",
		},
		error: {
			main: "#f44336",
		},
		warning: {
			main: "#ff9800",
		},
		info: {
			main: "#2196f3",
		},
		success: {
			main: "#4caf50",
		},
		divider: "rgba(0, 0, 0, 0.12)",
	},
	typography: {
		h1: {
			fontFamily: "Roboto",
			fontWeight: 1000,
		},
	},
	shape: {
		borderRadius: 4,
	},
	overrides: {
		MuiSwitch: {
			root: {
				width: 42,
				height: 26,
				padding: 0,
				margin: 8,
			},
			switchBase: {
				padding: 1,
				"&$checked, &$colorPrimary$checked, &$colorSecondary$checked": {
					transform: "translateX(16px)",
					color: "#fff",
					"& + $track": {
						opacity: 1,
						border: "none",
					},
				},
			},
			thumb: {
				width: 24,
				height: 24,
			},
			track: {
				borderRadius: 13,
				border: "1px solid #bdbdbd",
				backgroundColor: "#fafafa",
				opacity: 1,
				transition:
					"background-color 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms,border 300ms cubic-bezier(0.4, 0, 0.2, 1) 0ms",
			},
		},
	},
	props: {
		MuiTooltip: {
			arrow: true,
		},
	},
});
