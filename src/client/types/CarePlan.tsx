import { Goal } from "./Goal";

interface CarePlan {
	_id: string;
	Id: string;
	DisplayName: string;
	ClientId: string;
	Goals: Array<Goal>;
}
export type { CarePlan };
