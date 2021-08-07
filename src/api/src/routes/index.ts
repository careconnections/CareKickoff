import { clients } from "./Clients";
import { reports } from "./Reports";
import { employees } from "./Employees";
import { careplans } from "./Careplans";
import { logout, login } from "./Auth";

export const allRoutes = [
	clients,
	reports,
	employees,
	careplans,
	logout,
	login,
];
