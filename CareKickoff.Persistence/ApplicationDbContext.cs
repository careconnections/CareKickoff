using System;
using System.Linq;
using CareKickoff.Domain.Enums;
using CareKickoff.Domain.Interfaces.Entities;
using CareKickoff.Persistence.Records;
using Microsoft.EntityFrameworkCore;

namespace CareKickoff.Persistence {
    public class ApplicationDbContext : DbContext {
        internal DbSet<EmployeeRecord> Employees { get; set; }
        internal DbSet<ClientRecord> Clients { get; set; }
        internal DbSet<AuthorizationRecord> Authorizations { get; set; }
        internal DbSet<CareplanRecord> Careplans { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<ClientRecord>()
                .Property(_ => _.Gender)
                .HasConversion(
                    _ => _.ToString(),
                    _ => (GenderType) Enum.Parse(typeof(GenderType), _));

            modelBuilder
                .Entity<AuthorizationRecord>()
                .HasKey(_ => new { _.Id, _.EmployeeId, _.ClientId });

            InitialSeed(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }

        private static void InitialSeed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ClientRecord>()
                .HasData(
                    new ClientRecord {
                        Id = 1,
                        FirstName = "Paul",
                        LastName = "Driver",
                        BirthDate = DateTime.Parse("1980-05-20T00:00:00"),
                        Gender = GenderType.Male
                    },
                    new ClientRecord {
                        Id = 2,
                        FirstName = "Scarlet",
                        LastName = "Jonahson",
                        BirthDate = DateTime.Parse("1985-01-11T00:00:00"),
                        Gender = GenderType.Female
                    },
                    new ClientRecord {
                        Id = 3,
                        FirstName = "Jessica",
                        LastName = "Albo",
                        BirthDate = DateTime.Parse("1982-04-11T00:00:00"),
                        Gender = GenderType.Female
                    },
                    new ClientRecord {
                        Id = 4,
                        FirstName = "Jwayne",
                        LastName = "Dohnson",
                        BirthDate = DateTime.Parse("1972-12-30T00:00:00"),
                        Gender = GenderType.Male
                    },
                    new ClientRecord {
                        Id = 5,
                        FirstName = "Prad",
                        LastName = "Bitt",
                        BirthDate = DateTime.Parse("1940-05-20T00:00:00"),
                        Gender = GenderType.Male
                    }
                );
            
            modelBuilder.Entity<EmployeeRecord>()
                .HasData(
                    new EmployeeRecord {Id = 1, Name = "Sander"},
                    new EmployeeRecord {Id = 2, Name = "Peter"},
                    new EmployeeRecord {Id = 3, Name = "Chris"}
                );

            modelBuilder.Entity<AuthorizationRecord>()
                .HasData(
                    new AuthorizationRecord {Id = 1, EmployeeId = 1, ClientId = 1},
                    new AuthorizationRecord {Id = 2, EmployeeId = 1, ClientId = 2},
                    new AuthorizationRecord {Id = 3, EmployeeId = 1, ClientId = 4},
                    
                    new AuthorizationRecord {Id = 4, EmployeeId = 2, ClientId = 2},
                    new AuthorizationRecord {Id = 5, EmployeeId = 2, ClientId = 3},
                    
                    new AuthorizationRecord {Id = 6, EmployeeId = 3, ClientId = 3},
                    new AuthorizationRecord {Id = 7, EmployeeId = 3, ClientId = 4},
                    new AuthorizationRecord {Id = 8, EmployeeId = 3, ClientId = 5}
                );

            modelBuilder.Entity<CareplanRecord>()
                .HasData(
                    new CareplanRecord { Id = 1, ClientId = 1, DisplayName = "Careplan Paul Driver, 2019" },
                    new CareplanRecord { Id = 2, ClientId = 2, DisplayName = "Careplan" },
                    new CareplanRecord { Id = 3, ClientId = 2, DisplayName = "Omaha plan" },
                    new CareplanRecord { Id = 4, ClientId = 3, DisplayName = "Careplan" },
                    new CareplanRecord { Id = 5, ClientId = 4, DisplayName = "Careplan" },
                    new CareplanRecord { Id = 6, ClientId = 5, DisplayName = "Careplan 2019" },
                    new CareplanRecord { Id = 7, ClientId = 5, DisplayName = "Careplan 2018" }
                );
        }

        public override int SaveChanges() {
            var currentTime = DateTime.UtcNow;
            
            var addedEntities = ChangeTracker.Entries()
                .Where(_ => _.State == EntityState.Added)
                .Where(_ => _.Entity is IEntityWithTracking)
                .ToList();
            
            addedEntities.ForEach(_ => {
                _.Property(nameof(IEntityWithTracking.CreationDate)).CurrentValue = currentTime;
                _.Property(nameof(IEntityWithTracking.ModificationDate)).CurrentValue = currentTime;
            });

            var editedEntities = ChangeTracker.Entries()
                .Where(_ => _.State == EntityState.Modified)
                .Where(_ => _.Entity is IEntityWithTracking)
                .ToList();
            
            editedEntities.ForEach(_ => {
                _.Property(nameof(IEntityWithTracking.ModificationDate)).CurrentValue = currentTime;
            });

            return base.SaveChanges();
        }
    }
}