import { Schema, model, ObjectId } from "mongoose";

interface Report {
	_id: ObjectId;
	Subject: string;
	Text: string;
	HasPriority: boolean;
	CarePlanGoalId: string;
	ClientId: string;
	CreatedBy: string;
	CreatedAt: string;
}

const schema = new Schema<Report>({
	Name: { type: String, required: true },
	Subject: { type: String, required: true },
	Text: { type: String, required: true },
	HasPriority: { type: Boolean, required: true },
	CarePlanGoalId: { type: String },
	ClientId: { type: String, required: true },
	CreatedBy: { type: String, required: true },
	CreatedAt: { type: String, required: true },
});

export const ReportsModel = model<Report>("report", schema);
