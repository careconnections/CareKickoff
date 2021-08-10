import { Client } from "./Client";

interface ClientListProps {
	employeeClients: Array<Client>;
	onChange: (id: string) => void;
}
export type { ClientListProps };
