import { useState } from "react";
import { useEffect } from "react";
import { Report, Client } from "../types";

export function useReports(selectedClient: Client) {
	const [clientReports, setClientReports] = useState<Array<Report>>();

	useEffect(() => {
		if (!selectedClient) return;

		fetch(`${process.env.API}/reports/${selectedClient.NativeId}`)
			.then(
				(response: Response): Promise<Array<Report>> => response.json()
			)
			.then((clients: Array<Report>) => {
				console.log(clients);
				setClientReports(clients);
			})
			.catch((err: TypeError) => console.log(err));
	}, [selectedClient]);

	return [clientReports, setClientReports];
}
