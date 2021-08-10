import * as hapi from "@hapi/hapi";

import { Employee, EmployeesModel } from "../models";

export const auth: Array<hapi.ServerRoute> = [
	/* 	{
		method: "GET",
		path: "/login",
		options: {
			auth: {
				mode: "try",
			},
			plugins: {
				"hapi-auth-cookie": {
					redirectTo: false,
				},
			},
			handler: async (request: any, h: hapi.ResponseToolkit) => {
				request.log(`GET login :${JSON.stringify(request.auth)}`);
				if (request.auth.isAuthenticated) {
					return h.response("").code(200);
				} else {
					return h.response("Not logged in anymore").code(401);
				}
			},
		},
	}, */
	{
		method: "POST",
		path: "/login",
		options: {
			/* 	auth: {
				mode: "try",
			}, */
			handler: async (request: any, h: hapi.ResponseToolkit) => {
				const { username } = JSON.parse(request.payload);

				if (!username) {
					return h
						.response({
							message: "No username",
						})
						.type("application/json")
						.code(401);
				}

				const employee: Employee | null = await EmployeesModel.findOne({
					Name: username,
				});

				if (!employee) {
					return h
						.response({
							message: "No employee with that username",
						})
						.type("application/json")
						.code(401);
				}

				// request.cookieAuth.set({ id: employee._id });
				return h
					.response({
						message: "Successfully logged in",
						id: employee._id,
					})
					.type("application/json")
					.code(200);
			},
		},
	},
	{
		method: "POST",
		path: "/logout",
		options: {
			/* 			auth: {
				mode: "try",
			}, */
			handler: (request: any, h: hapi.ResponseToolkit) => {
				// request.cookieAuth.clear();
				return h
					.response({ message: "Successfully logged out" })
					.type("application/json");
			},
		},
	},
];
