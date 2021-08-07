"use strict";

import { ClientsModel, Employee, EmployeesModel } from "../models";

export const clients = {
	method: "GET",
	path: "/clients",
	options: {
		auth: { mode: "required" },
	},
	handler: async (request: any, h: any) => "clients",
};
