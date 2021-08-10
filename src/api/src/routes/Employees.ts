"use strict";

import * as hapi from "@hapi/hapi";
import { ObjectId } from "mongodb";
import {  EmployeesModel } from "../models";

export const employees: hapi.ServerRoute = {
	method: "GET",
	path: "/employee/{id}",
	options: {
		handler: async (request: hapi.Request, h: hapi.ResponseToolkit) => {
			const id = new ObjectId(request.params.id);
			return EmployeesModel.findOne({
				_id: id,
			});
		},
	},
};
