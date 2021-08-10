import { useState } from "react";
import { useEffect } from "react";
import { Employee, Client } from "../types";

export function useClients(employee: Employee) {
	const [employeeClients, setEmployeeClients] = useState<Array<Client>>();

	useEffect(() => {
		if (!employee) return;

		fetch(
			`${process.env.API}/clients/${JSON.stringify(
				employee.AuthorizedClients
			)}`
		)
			.then(
				(response: Response): Promise<Array<Client>> => response.json()
			)
			.then((clients: Array<Client>) => setEmployeeClients(clients))
			.catch((err: TypeError) => console.log(err));
	}, [employee]);

	return [employeeClients, setEmployeeClients];
}
