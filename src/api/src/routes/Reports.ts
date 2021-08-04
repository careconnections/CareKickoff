"use strict";
export const reports = {
	method: "GET",
	path: "/reports",
	options: {
		auth: "simple",
	},
	handler: async (request: any, h: any) => {
		return "Reports";
	},
};
