"use strict";
export const clients = {
	method: "GET",
	path: "/clients",
	options: {
		auth: "simple",
	},
	handler: async (request: any, h: any) => {
		return "Clients";
	},
};
