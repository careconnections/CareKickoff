import {
	List,
	ListItem,
	ListItemAvatar,
	Avatar,
	ListItemText,
} from "@material-ui/core";
import { FunctionComponent, useState, useEffect } from "react";
import { ClientListProps } from "../types";

import PersonIcon from "@material-ui/icons/Person";
import { useClientListStyles } from "../styles";

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
		<List dense className={classes.list}>
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
