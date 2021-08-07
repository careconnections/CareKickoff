export const login: any = {
	method: "GET",
	path: "/",
	options: {
		auth: "simple",
	},
	handler: (request: any, h: any) => "Logged in",
};

export const logout: any = {
	method: "GET",
	path: "/logout",
	handler: (request: any, h: any) => h.response("Logged out").code(401),
};
