# The CareConnections Kickoff Assignment

## Description
I started with modeling the domain and went from there. For the persistence features i used EF Core and the SQLite provider. This so the project can easily be started. I hardcoded a initial seed to speed things up.

---
## Functionality
- Employee
- Client
- Authorization
- Careplan
- ~~Goals~~
- ~~Reports~~

---
## Instructions
1) Clone the repository.
2) Run the CareKickoff.Api project.

You should be presented with Swagger after this, where you can test the API. Use one of the provided API keys to mock a logged-in state for a specific user.

- Sander - DAE89B8D-5E8D-46D2-8449-EB74BA928A4B
- Peter - E1B500C6-69C0-4AFC-9729-03C526827E33
- Chris - 56D27A3E-D2EC-41C6-B6A7-301743948CB8

---
## Notes
- I did not implement the complete structure provided in the json files, but i think the different types of relations are present.

- The unit tests are very basic CRUD tests, this to save time. I would probably not use the database seed as the initial state, as this can be confusing in the state the database is in.

- The database context for the unit tests is simply removed before/after every test at this moment. Obviously it would be better to use transactions, an in-memory database or mock the dependencies.

- Authentication is limited to hardcoded API keys, just to enable calling the API in an employee context. This saved time but an api key is totally irrelevent for this use case. Luckily, it's easy enough to replace as it's a custom `AuthenticationHandler` implementation.