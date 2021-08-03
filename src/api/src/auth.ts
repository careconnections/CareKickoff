"use strict";

import { Request } from "@hapi/hapi";
import Bcrypt from "bcryptjs";

interface User {
	username: string;
	password: string;
	name: string;
	id: string;
}

interface Credentials {
	name: string;
	id: string;
}

const salt: string = "Care";

const users: { [name: string]: User } = {
	john: {
		username: "john",
		password:
			"$2y$12$5QVb7JoNpT.3n1JdiRjLY.vja0gQOskIEQJ3.dl4qwxVbMiYBlg02", // 123
		name: "John Doe",
		id: "2133d32a",
	},
};

export const validate = async (
	request: Request,
	username: string,
	password: string
) => {
	const user: User = users[username];

	if (user) {
		const isValid: boolean = await Bcrypt.compare(
			password + salt,
			user.password
		);
		const credentials: Credentials = { id: user.id, name: user.name };

		return { credentials, isValid };
	} else {
		return { credentials: null, isValid: false };
	}
};
