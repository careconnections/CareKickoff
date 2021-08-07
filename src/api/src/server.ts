"use strict";

import * as Hapi from "@hapi/hapi";
import * as routes from "./routes";
import * as auth from "./auth";

export let server: Hapi.Server;

export const start = async function () {
	server = Hapi.server({
		debug: { request: ["*"], log: ["*"] },
		port: process.env.PORT,
		host: "0.0.0.0",
	});

	await auth.init(server);

	server.route(routes.allRoutes);

	await server.register({
		plugin: require("hapi-modern-cors"),
		options: {},
	});

	await server.start();

	console.log(`Listening on ${server.settings.host}:${server.settings.port}`);
};

process.on("unhandledRejection", (err) => {
	console.error("unhandledRejection");
	console.error(err);
	process.exit(1);
});
