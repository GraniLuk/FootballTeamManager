using DoodleApi;
using FootballManager.Controllers;
using FootballManager.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FootballManagerTests {
    [TestFixture]
    public class DoodleRefreshTests {
        [Test]
        public void DoodleRefresh_UpdatesActiveOnPlayer() {
            var doodleApiMoq = new Mock<IApi>();
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            var playerController = new PlayerController(doodleApiMoq.Object, new ApplicationDbContext(dbOptions));

            //playerController.DoodleRefresh(DateTime.UtcNow);

        }
    }
}
