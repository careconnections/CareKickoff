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
		name: "sid_care_connections",
		password: "superSecretsuperSecretsuperSecret",
		isSecure: false,
		isSameSite: "Lax",
	},

	validateFunc: async (request: Hapi.Request, session: any) => {
		const employee: Models.Employee | null =
			await Models.EmployeesModel.findOne({
				_id: session.id,
			});

		if (!employee) {
			return { valid: false };
		} else {
			return { valid: true, credentials: employee };
		}
	},
};
