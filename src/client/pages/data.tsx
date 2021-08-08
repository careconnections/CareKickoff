export const employees = [
	{ Name: "Sander", EmployeeId: "1", AuthorizedClients: ["1", "2", "4"] },
	{ Name: "Peter", EmployeeId: "2", AuthorizedClients: ["2", "3"] },
	{ Name: "Chris", EmployeeId: "3", AuthorizedClients: ["3", "4", "5"] },
];
export const clients = [
	{
		FirstName: "Paul",
		LastName: "Driver",
		BirthDate: "1980-05-20T00:00:00",
		Gender: "male",
		NativeId: "1",
	},
	{
		FirstName: "Scarlet",
		LastName: "Jonahson",
		BirthDate: "1985-01-11T00:00:00",
		Gender: "female",
		NativeId: "2",
	},
	{
		FirstName: "Jessica",
		LastName: "Albo",
		BirthDate: "1982-04-11T00:00:00",
		Gender: "female",
		NativeId: "3",
	},
	{
		FirstName: "Jwayne",
		LastName: "Dohnson",
		BirthDate: "1972-12-30T00:00:00",
		Gender: "male",
		NativeId: "4",
	},
	{
		FirstName: "Prad",
		LastName: "Bitt",
		BirthDate: "1940-05-20T00:00:00",
		Gender: "male",
		NativeId: "5",
	},
];
export const rapports = [
	{
		Subject: "High bloodpressure",
		Text: "Client seems to have excessive lifestyle, causing high bloodpressure. Adviced to stop driving so fast.",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "1",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-12T15:22:00",
	},
	{
		Subject: "Short attention span",
		Text: "Client only pays attention for 9.8 seconds",
		HasPriority: false,
		CarePlanGoalId: "2",
		ClientId: "1",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-11T14:00:00",
	},
	{
		Subject: "Burn marks",
		Text: "Mr. Driver burnt his hand cooking dinner.",
		HasPriority: true,
		CarePlanGoalId: "",
		ClientId: "1",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-10T08:40:00",
	},
	{
		Subject: "Trouble walking",
		Text: "Ms. Jonahson has trouble walking for more than a few minutes at a time",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "2",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-12T15:00:00",
	},
	{
		Subject: "Random language loss",
		Text: "Client sometimes seems lost trying to translate her words, and she can only speak Japanese for a few minutes",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "2",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-11T12:00:00",
	},
	{
		Subject: "Quiet day",
		Text: "Everything went well today",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "2",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-08T17:30:00",
	},
	{
		Subject: "Quiet day",
		Text: "Nothing special happened",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "3",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-12T16:50:00",
	},
	{
		Subject: "Physical exercise",
		Text: "Client tried surfing today to regain mobility, went well",
		HasPriority: false,
		CarePlanGoalId: "1",
		ClientId: "3",
		CreatedBy: "Peter",
		CreatedAt: "2019-08-11T15:00:00",
	},
	{
		Subject: "Sprained ankle",
		Text: "Ms. Albo sprained her ankle",
		HasPriority: false,
		CarePlanGoalId: "1",
		ClientId: "3",
		CreatedBy: "Chris",
		CreatedAt: "2019-08-04T11:19:00",
	},
	{
		Subject: "Too much protein",
		Text: "Mr. Dohnson exceeded his agreed limit of maximum 5 protein shakes a day",
		HasPriority: false,
		CarePlanGoalId: "1",
		ClientId: "4",
		CreatedBy: "Sander",
		CreatedAt: "2019-08-12T15:22:00",
	},
	{
		Subject: "Couldn't get out of bed",
		Text: "Client refused to get up and stayed in bed all day",
		HasPriority: false,
		CarePlanGoalId: "",
		ClientId: "4",
		CreatedBy: "Remco",
		CreatedAt: "2019-08-10T22:45:00",
	},
];
export const careplans = [
	{
		Id: "1",
		DisplayName: "Careplan Paul Driver, 2019",
		ClientId: "1",
		Goals: [
			{ DisplayName: "Drive slower", GoalId: "1" },
			{ DisplayName: "Work on focus", GoalId: "2" },
		],
	},
	{
		Id: "1",
		DisplayName: "Careplan",
		ClientId: "2",
		Goals: [
			{ DisplayName: "Get back sense of direction", GoalId: "1" },
			{ DisplayName: "Sleep enough", GoalId: "2" },
			{ DisplayName: "Learn new languages", GoalId: "2" },
		],
	},
	{
		Id: "2",
		DisplayName: "Omaha plan",
		ClientId: "2",
		Goals: [{ DisplayName: "Bring more structure in life", GoalId: "1" }],
	},
	{
		Id: "1",
		DisplayName: "Careplan",
		ClientId: "3",
		Goals: [{ DisplayName: "Exercise enough", GoalId: "1" }],
	},
	{
		Id: "1",
		DisplayName: "Careplan",
		ClientId: "4",
		Goals: [{ DisplayName: "Limit amount of food", GoalId: "1" }],
	},
	{
		Id: "2",
		DisplayName: "Careplan 2019",
		ClientId: "5",
		Goals: [
			{ DisplayName: "Style hair every morning", GoalId: "1" },
			{ DisplayName: "Contact mother weekly", GoalId: "2" },
		],
	},
	{
		Id: "1",
		DisplayName: "Careplan 2018",
		ClientId: "5",
		Goals: [
			{ DisplayName: "Style hair every morning", GoalId: "1" },
			{ DisplayName: "Contact mother weekly", GoalId: "2" },
		],
	},
];
