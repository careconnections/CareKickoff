import { Schema, model } from "mongoose";

interface Client {
	Name: string;
	ClientId: string;
	AuthorizedClients: Array<string>;
}

const schema = new Schema<Client>({
	Name: { type: String, required: true },
	ClientId: { type: String, required: true },
	AuthorizedClients: { type: Array, required: true },
});

export const ClientsModel = model<Client>("client", schema);
