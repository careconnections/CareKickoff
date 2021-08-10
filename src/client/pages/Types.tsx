interface Client {
	_id: string;
	FirstName: string;
	LastName: string;
	BirthDate: string;
	Gender: string;
	NativeId: string;
}

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

interface CarePlan {
	_id: string;
	Id: string;
	DisplayName: string;
	ClientId: string;
	Goals: Array<Goal>;
}

interface Employee {
	_id: string;
	Name: string;
	EmployeeId: string;
	AuthorizedClients: Array<string>;
}

interface Goal {
	DisplayName: string;
	GoalId: string;
}

interface LoginData {
	id: string;
	message: string;
}

interface ClientListProps {
	employeeClients: Array<Client>;
	onChange: (id: string) => void;
}

export type {
	Client,
	Report,
	CarePlan,
	Employee,
	Goal,
	LoginData,
	ClientListProps,
};
