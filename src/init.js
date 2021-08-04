db = db.getSiblingDB('care-connections-db');

db.createCollection('clients');
db.createCollection('careplans');
db.createCollection('employees');
db.createCollection('reports');

db.clients.insertMany(eval(cat("../init/clients.json")));
db.careplans.insertMany(eval(cat("../init/careplans.json")));
db.employees.insertMany(eval(cat("../init/employees.json")));
db.reports.insertMany(eval(cat("../init/reports.json")));

db.createUser(
    {
        user: "careConnections",
        pwd: "careConnections",
        roles: [{ role: "readWrite", db: "care-connections-db" }]
    }
)