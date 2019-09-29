using System.IO;
using CareKickoff.Infrastructure.Factories;
using CareKickoff.Infrastructure.Services;
using CareKickoff.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CareKickoff.Specification {
    [TestFixture]
    internal abstract class TestFixtureBase {
        private const string DatabaseFileName = "unit-tests.db";
        private ApplicationDbContext _applicationDbContext;
        private AuthorizationService _authorizationService;
        private EmployeeService _employeeService;
        private ClientService _clientService;

        protected AuthorizationService AuthorizationService {
            get {
                if (_authorizationService == null) {
                    _authorizationService = AuthorizationServiceFactory.Create(ApplicationDbContext);
                }

                return _authorizationService;
            }
        }

        
        protected EmployeeService EmployeeService {
            get {
                if (_employeeService == null) {
                    _employeeService = EmployeeServiceFactory.Create(ApplicationDbContext);
                }

                return _employeeService;
            }
        }
        
        protected ClientService ClientService {
            get {
                if (_clientService == null) {
                    _clientService = ClientServiceFactory.Create(ApplicationDbContext);
                }

                return _clientService;
            }
        }

        private ApplicationDbContext ApplicationDbContext {
            get {
                if (_applicationDbContext == null) {
                    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    optionsBuilder.UseSqlite($"Data Source={DatabaseFileName}");
                    _applicationDbContext = new ApplicationDbContext(optionsBuilder.Options);
                }

                return _applicationDbContext;
            }
        }

        [SetUp]
        [TearDown]
        protected void Drop() {
            if (File.Exists(DatabaseFileName)) {
                File.Delete(DatabaseFileName);
            }

            _applicationDbContext = null;
            _authorizationService = null;
            _employeeService = null;
            _clientService = null;
        }
    }
}
