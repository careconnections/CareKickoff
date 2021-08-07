import * as hapi from "@hapi/hapi";

import * as models from "../models";

export const auth = [
	{
		method: "POST",
		path: "/login",
		options: {
			auth: {
				mode: "try",
			},
			handler: async (request: any, h: hapi.ResponseToolkit) => {
				const { username } = request.payload;

				if (!username) {
					return h.response("No username").code(401);
				}

				const employee: models.Employee | null =
					await models.EmployeesModel.findOne({
						Name: username,
					});

				if (!employee) {
					return h
						.response("No employee with that username")
						.code(401);
				}

				request.cookieAuth.set({ id: employee._id });
				return h.response("Successfully logged in").code(200);
			},
		},
	},
	{
		method: "GET",
		path: "/logout",
		options: {
			handler: (request: any, h: hapi.ResponseToolkit) => {
				request.cookieAuth.clear();
				return h.response("Successfully logged out").code(200);
			},
		},
	},
];
