import { Grid, TextField, Button } from "@material-ui/core";
import { FormEvent, FunctionComponent } from "react";

export const LoginForm: FunctionComponent<{
	onSubmit: (e: FormEvent<HTMLFormElement>) => Promise<void>;
}> = ({ onSubmit }) => {
	return (
		<form onSubmit={onSubmit} method="post">
			<Grid container spacing={2} justifyContent="flex-end">
				<Grid item xs={12}>
					<TextField
						fullWidth
						id="filled-basic"
						label="Employee name"
						name="username"
						variant="filled"
						color="secondary"
					/>
				</Grid>
				<Grid item>
					<Button variant="contained" color="primary" type="submit">
						Sign in
					</Button>
				</Grid>
			</Grid>
		</form>
	);
};
