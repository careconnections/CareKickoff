import {
	List,
	ListItem,
	ListItemAvatar,
	Avatar,
	ListItemText,
	makeStyles,
} from "@material-ui/core";
import PersonIcon from "@material-ui/icons/Person";
import { FunctionComponent, useState } from "react";
import ClientStyle from "../styles/Clients.module.css";
import { theme } from "../styles/theme";
import { ClientListProps } from "./Types";
import { useEffect } from "react";

const useClientListStyles = makeStyles({
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

const ClientList: FunctionComponent<ClientListProps> = ({
	employeeClients,
	onChange,
}) => {
	const classes = useClientListStyles();

	const [selectedClient, setSelectedClient] = useState<string>(
		employeeClients[0].NativeId
	);

	useEffect(() => {
		onChange(selectedClient);
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	const handleChange = (id: string): void => {
		onChange(id);
		setSelectedClient(id);
	};

	return (
		<List dense className={[ClientStyle.list, classes.list]}>
			{employeeClients &&
				employeeClients.map((client, i) => (
					<ListItem
						key={i}
						divider
						button
						id={client.NativeId}
						onClick={() => handleChange(client.NativeId)}
						selected={client.NativeId === selectedClient}
					>
						<ListItemAvatar>
							<Avatar className={classes.avatar}>
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
	);
};

export { ClientList };
