"use strict";

import * as Hapi from "@hapi/hapi";
import * as Models from "./models";

import basicAuth from "@hapi/basic";

export async function init(server: Hapi.Server) {
	await server.register(basicAuth);
	server.auth.strategy("simple", "basic", { validate });
	server.auth.default("simple");
}

const validate = async (request: Hapi.Request) => {
	request.log("error", "Event auth");

	const authorization = Buffer.from(
		request.headers.authorization.split(" ")[1],
		"base64"
	)
		.toString()
		.split(":");

	const employee: Models.Employee | null =
		await Models.EmployeesModel.findOne({
			Name: authorization[0],
		});

	const credentials = employee
		? { id: employee._id.toHexString(), name: employee.Name }
		: null;

	return {
		credentials,
		isValid: employee,
	};
};
