import { Schema, model } from "mongoose";

interface Careplan {
	Name: string;
	CareplanId: string;
	AuthorizedClients: Array<string>;
}

const schema = new Schema<Careplan>({
	Name: { type: String, required: true },
	CareplanId: { type: String, required: true },
	AuthorizedClients: { type: Array, required: true },
});

export const CareplansModel = model<Careplan>("careplan", schema);
