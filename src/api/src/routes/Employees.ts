"use strict";

import { EmployeesModel } from "../models";

export const employees = {
	method: "GET",
	path: "/employees",
	options: {
		auth: "simple",
	},
	handler: async (request: any, h: any) => {
		return EmployeesModel.find();
	},
};
