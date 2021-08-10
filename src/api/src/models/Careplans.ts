import { Schema, model, ObjectId } from "mongoose";

interface Careplan {
	_id: ObjectId;
	Id: string;
	DisplayName: string;
	ClientId: string;
	Goals: Array<Goal>;
}

interface Goal {
	DisplayName: string;
	GoalId: string;
}

const schema = new Schema<Careplan>({
	Id: { type: String, required: true },
	DisplayName: { type: String, required: true },
	ClientId: { type: String, required: true },
	Goals: { type: Array, required: true },
});

export const CareplansModel = model<Careplan>("careplan", schema);
