using CareConnections.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace CareConnections.Api.Models
{
    public class AppDbContext : DbContext
    {
        static readonly JsonParser _jsonParser = new();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Nothing
        }

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Report>? Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var clients = _jsonParser.GetClientsFromJson("Data/clients.json");
            var employees = _jsonParser.GetEmployeesFromJson("Data/employees.json");
            var reports = _jsonParser.GetReportsFromJson("Data/reports.json");

            clients?.ForEach(c => modelBuilder.Entity<Client>().HasData(c));
            employees?.ForEach(e => modelBuilder.Entity<Employee>().HasData(e));
            reports?.ForEach(r => modelBuilder.Entity<Report>().HasData(r));
        }
    }
}