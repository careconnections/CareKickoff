"use strict";

import { ReportsModel } from "../models";

export const reports = {
	method: "GET",
	path: "/reports/{id}",
	handler: async (request: any, h: any) => {
		return ReportsModel.find({ ClientId: request.params.id });
	},
};
