interface Report {
	_id: string;
	Subject: string;
	Text: string;
	HasPriority: boolean;
	CarePlanGoalId: string;
	ClientId: string;
	CreatedBy: string;
	CreatedAt: string;
}
export type { Report };
