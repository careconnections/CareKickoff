using System.IO;
using NUnit.Framework;

namespace CareKickoff.Specification.Base {
    [TestFixture]
    internal abstract class TestFixtureBase {
        private const string DatabaseFileName = "unit-tests.db";

        [SetUp]
        [TearDown]
        protected void Drop() {
            if (File.Exists(DatabaseFileName)) {
                File.Delete(DatabaseFileName);
            }
        }
    }
}
