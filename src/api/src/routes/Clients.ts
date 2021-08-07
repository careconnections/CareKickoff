"use strict";
export const clients = {
	method: "GET",
	path: "/clients",
	/* 	options: {
		auth: { mode: "required" },
	}, */
	handler: async (request: any, h: any) => {
		return "Clients";
	},
};
