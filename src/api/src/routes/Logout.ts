export const logout: any = {
	method: "GET",
	path: "/logout",
	handler: (request: any, h: any) => h.response("Logged out").code(401),
};
