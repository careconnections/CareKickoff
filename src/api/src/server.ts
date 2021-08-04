"use strict";

import * as Hapi from "@hapi/hapi";
import * as routes from "./routes";

import basic from "@hapi/basic";

import { validate } from "./auth";

export let server: Hapi.Server;

export const start = async function () {
	server = Hapi.server({
		port: process.env.PORT,
		host: "0.0.0.0",
	});

	await server.register(basic);

	server.auth.strategy("simple", "basic", { validate });
	server.auth.default("simple");

	server.route(routes.allRoutes);

	await server.start();

	console.log(`Listening on ${server.settings.host}:${server.settings.port}`);
};

process.on("unhandledRejection", (err) => {
	console.error("unhandledRejection");
	console.error(err);
	process.exit(1);
});
