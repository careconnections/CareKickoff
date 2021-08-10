import { useState } from "react";
import { useEffect } from "react";
import { Employee } from "../types";

export default function useEmployee(id: string | null) {
	const [employee, setEmployee] = useState<Employee>();

	useEffect(() => {
		fetch(`${process.env.API}/employee/${id}`)
			.then((response: Response): Promise<Employee> => response.json())
			.then((employee: Employee) => setEmployee(employee))
			.catch((err: TypeError) => console.log(err));
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	return [employee, setEmployee];
}
