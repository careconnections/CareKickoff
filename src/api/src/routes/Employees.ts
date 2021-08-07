"use strict";

import { EmployeesModel } from "../models";

export const employees = {
	method: "GET",
	path: "/employee/",
	handler: async (request: any, h: any) => {
		return EmployeesModel.find();
	},
};
