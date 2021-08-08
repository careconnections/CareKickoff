import {
	List,
	ListItem,
	ListItemAvatar,
	Avatar,
	ListItemText,
	Card,
} from "@material-ui/core";
import PersonIcon from "@material-ui/icons/Person";
import ClientStyle from "../styles/Clients.module.css";
import { theme } from "../styles/theme";
import { clients, rapports } from "./data";

export function ClientList({
	employeeClients,
	setSelectedClient,
	setClientRapports,
	selectedClient,
}) {
	return (
		<Card elevation={4}>
			<List
				dense
				className={ClientStyle.list}
				style={{
					overflowY: "auto",
					height: "100%",
					padding: 0,
				}}
			>
				{employeeClients.map((client, i) => (
					<ListItem
						key={i}
						divider
						button
						id={client.NativeId}
						onClick={() => {
							setSelectedClient(
								clients.find(
									(c) => c.NativeId === client.NativeId
								)
							);
							setClientRapports(() =>
								rapports.filter(
									(r) => r.ClientId === client.NativeId
								)
							);
						}}
						selected={client.NativeId === selectedClient.NativeId}
					>
						<ListItemAvatar>
							<Avatar
								style={{
									color: theme.palette.getContrastText(
										theme.palette.primary.main
									),
									backgroundColor: theme.palette.primary.main,
								}}
							>
								<PersonIcon />
							</Avatar>
						</ListItemAvatar>
						<ListItemText
							primary={`${client.FirstName} ${client.LastName}`}
							secondary={client.BirthDate.split("T")[0]}
						/>
					</ListItem>
				))}
			</List>
		</Card>
	);
}
