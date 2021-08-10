import { useState } from "react";
import { useEffect } from "react";
import { CarePlan, Client } from "../types";

export function useCarePlans(selectedClient: Client) {
	const [selectedCarePlans, setSelectedCarePlans] =
		useState<Array<CarePlan>>();

	useEffect(() => {
		if (!selectedClient) return;

		fetch(`${process.env.API}/careplans/${selectedClient.NativeId}`)
			.then(
				(response: Response): Promise<Array<CarePlan>> =>
					response.json()
			)
			.then((clients: Array<CarePlan>) => {
				console.log(clients);
				setSelectedCarePlans(clients);
			})
			.catch((err: TypeError) => console.log(err));
	}, [selectedClient]);

	return [selectedCarePlans, setSelectedCarePlans];
}
