"use strict";
export const careplans = {
	method: "GET",
	path: "/careplans",
	options: {
		auth: "simple",
	},
	handler: async (request: any, h: any) => {
		return "Careplans";
	},
};
