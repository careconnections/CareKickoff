"use strict";

import * as Hapi from "@hapi/hapi";

import * as Models from "./models";

export const init = async (server: Hapi.Server) => {
	await server.register(require("@hapi/cookie"));
	server.auth.strategy("session", "cookie", validateCookie);
	server.auth.default("session");
};

const validateCookie: any = {
	cookie: {
		name: "careConnections",
		password: "superSecretsuperSecretsuperSecret",
		isSecure: false,
	},

	redirectTo: "/login",

	validateFunc: async (request: Hapi.Request, session: any) => {
		const employee: Models.Employee | null =
			await Models.EmployeesModel.findOne({
				_id: session.id,
			});

		if (!employee) {
			return { valid: false };
		}

		return { valid: true, credentials: employee };
	},
};

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
