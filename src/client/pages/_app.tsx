import "../styles/globals.css";
import type { AppProps } from "next/app";
import { ThemeProvider } from "@material-ui/core";
import { theme } from "../styles/theme";
import { SnackbarProvider } from "notistack";

function MyApp({ Component, pageProps }: AppProps) {
	return (
		<SnackbarProvider maxSnack={3}>
			<ThemeProvider theme={theme}>
				<Component {...pageProps} />
			</ThemeProvider>
		</SnackbarProvider>
	);
}
export default MyApp;
