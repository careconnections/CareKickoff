"use strict";

import * as hapi from "@hapi/hapi";
import { ClientsModel, Employee, EmployeesModel } from "../models";
import { ObjectId } from "mongodb";

export const clients = {
	method: "GET",
	path: "/clients/{id}",
	options: {
		// auth: { mode: "required" },
		handler: async (request: hapi.Request, h: hapi.ResponseToolkit) => {
			return ClientsModel.find({
				NativeId: { $in: JSON.parse(request.params.id) },
			});
		},
	},
};
