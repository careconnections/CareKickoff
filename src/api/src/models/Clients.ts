import { ObjectId } from "mongodb";
import { Schema, model } from "mongoose";

interface Client {
	_id: ObjectId;
	FirstName: string;
	LastName: string;
	BirthDate: string;
	Gender: string;
	NativeId: string;
}

const schema = new Schema<Client>({
	_id: { type: ObjectId, required: true },
	FirstName: { type: String, required: true },
	LastName: { type: String, required: true },
	BirthDate: { type: String, required: true },
	Gender: { type: String, required: true },
	NativeId: { type: String, required: true },
});

export const ClientsModel = model<Client>("client", schema);
