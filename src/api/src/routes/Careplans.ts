"use strict";

import { CareplansModel } from "../models";

export const careplans = {
	method: "GET",
	path: "/careplans/{id}",
	options: {
		handler: async (request: any, h: any) => {
			return CareplansModel.find({ ClientId: request.params.id });
		},
	},
};
