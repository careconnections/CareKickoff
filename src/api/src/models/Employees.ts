import { ObjectId } from "mongodb";
import { Schema, model } from "mongoose";

export interface Employee {
	_id: ObjectId;
	Name: string;
	EmployeeId: string;
	AuthorizedClients: Array<string>;
}

const schema = new Schema<Employee>({
	_id: { type: ObjectId, required: true },
	Name: { type: String, required: true },
	EmployeeId: { type: String, required: true },
	AuthorizedClients: { type: Array, required: true },
});

export const EmployeesModel = model<Employee>("employee", schema);
