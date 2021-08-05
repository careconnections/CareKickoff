"use strict";

import * as Hapi from "@hapi/hapi";
import * as Models from "./models";

import basicAuth from "@hapi/basic";

interface Credentials {
	name: string;
	id: string;
}

export async function init(server: Hapi.Server) {
	await server.register(basicAuth);
	server.auth.strategy("simple", "basic", { validate });
	server.auth.default("simple");
}

const validate = async (
	request: Hapi.Request,
	username: string,
	password: string
) => {
	const employee: Models.Employee | null =
		await Models.EmployeesModel.findOne({
			Name: username,
		});

	const credentials = employee
		? { id: employee._id.toHexString(), name: employee.Name }
		: null;

	return {
		credentials,
		isValid: employee,
	};
};
