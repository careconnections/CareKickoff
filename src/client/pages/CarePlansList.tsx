import { Typography, List, ListItem } from "@material-ui/core";
import { FunctionComponent } from "react";
import { CarePlan, Goal } from "./Types";

export const CarePlansList: FunctionComponent<
	{ selectedCarePlans: Array<CarePlan> } | undefined
> = ({ selectedCarePlans }) => {
	return (
		<List>
			{selectedCarePlans &&
				selectedCarePlans.map((carePlan: CarePlan, i: number) => (
					<ListItem
						alignItems="flex-start"
						key={i}
						style={{
							flexDirection: "column",
						}}
						divider={selectedCarePlans.length > 1}
					>
						<Typography variant="h6" gutterBottom>
							{carePlan.DisplayName}
						</Typography>
						<List dense>
							<Typography variant="body1" gutterBottom>
								Goals
							</Typography>
							{carePlan.Goals.map((goal: Goal, i: number) => (
								<ListItem key={i} disableGutters>
									<Typography variant="body2">
										{goal.DisplayName}
									</Typography>
								</ListItem>
							))}
						</List>
					</ListItem>
				))}
		</List>
	);
};
