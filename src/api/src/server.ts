"use strict";

import * as Hapi from "@hapi/hapi";
import * as dotenv from "dotenv";

import basic from "@hapi/basic";

import { validate } from "./auth";

dotenv.config();

export let server: Hapi.Server;

export const init = async function (): Promise<Hapi.Server> {
	server = Hapi.server({
		port: process.env.PORT,
		host: "0.0.0.0",
	});

	await server.register(basic);

	server.auth.strategy("simple", "basic", { validate });
	server.auth.default("simple");

	server.route({
		method: "GET",
		path: "/",
		options: {
			auth: "simple",
		},
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
