import { Schema, model } from "mongoose";

interface Report {
	Name: string;
	ReportsId: string;
	AuthorizedClients: Array<string>;
}

const schema = new Schema<Report>({
	Name: { type: String, required: true },
	ReportsId: { type: String, required: true },
	AuthorizedClients: { type: Array, required: true },
});

export const ReportsModel = model<Report>("report", schema);
