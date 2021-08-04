"use strict";

import * as Hapi from "@hapi/hapi";
import * as Models from "./models";

interface Credentials {
	name: string;
	id: string;
}

export const validate = async (
	request: Hapi.Request,
	username: string,
	password: string
) => {
	const employee: Models.Employee | null =
		await Models.EmployeesModel.findOne({
			Name: username,
		});

	if (employee) {
		const credentials: Credentials = {
			id: employee._id.toHexString(),
			name: employee.Name,
		};

		return { credentials, isValid: true };
	} else {
		return { credentials: null, isValid: false };
	}
};
