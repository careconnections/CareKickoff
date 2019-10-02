using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CareKickoff.Persistence.Repositories {
    public abstract class RepositoryBase {
        protected ApplicationDbContext DataContext { get; }

        protected RepositoryBase(ApplicationDbContext ctx) {
            DataContext = ctx;
            DataContext.Database.EnsureCreated();
        }

        protected static void EnsureValidEntity(object model) {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, results, true);

            if (!isValid) {
                var exceptionMessage = String.Join(Environment.NewLine, results);
                throw new ValidationException(exceptionMessage);
            }
        }
    }
}