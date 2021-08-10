import { clients } from "./Clients";
import { reports } from "./Reports";
import { employees } from "./Employees";
import { careplans } from "./Careplans";
import { auth } from "./Auth";

export const allRoutes = [clients, reports, careplans, ...auth, employees];
