"use strict";

import { config } from "dotenv";
import Hapi from "@hapi/hapi";
import { Server } from "@hapi/hapi";

config();

export let server: Server;

export const init = async function (): Promise<Server> {
	server = Hapi.server({
		port: process.env.PORT,
		host: "0.0.0.0",
	});

	server.route({
		method: "GET",
		path: "/",
		handler: (request, h) => "Hello World!",
	});

	return server;
};

export const start = async function (): Promise<void> {
	console.log(`Listening on ${server.settings.host}:${server.settings.port}`);
	return server.start();
};

process.on("unhandledRejection", (err) => {
	console.error("unhandledRejection");
	console.error(err);
	process.exit(1);
});
