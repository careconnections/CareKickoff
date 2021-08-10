import * as server from "./server";
import * as database from "./mongodb";

database
	.start()
	.then(() => server.start())
	.catch((err) => console.log(err));
