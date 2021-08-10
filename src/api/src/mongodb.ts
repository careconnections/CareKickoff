import { connect, set } from "mongoose";

const mongodbURI = `mongodb://${process.env.MONGODB_USERNAME}:${process.env.MONGODB_PASSWORD}@${process.env.MONGODB_URI}/${process.env.MONGODB_DATABASE}`;

export async function start() {
	set("useNewUrlParser", true);
	set("useUnifiedTopology", true);

	return connect(mongodbURI)
		.then(() => console.log("Connected to mongodb"))
		.catch((err) => console.log(err));
}
