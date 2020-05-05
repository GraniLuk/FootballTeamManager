using DoodleApi;
using FootballManager.Controllers;
using FootballManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FootballManagerTests.PlayerControllerTests {
    [TestFixture]
    public class CreatePlayer {
        [Test]
        public void PlayerWithoutName_CreatePlayer_ReturnsView() {
            var doodleApiMoq = new Mock<IApi>();
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Add_writes_to_database")
               .Options;

            using (var context = new ApplicationDbContext(dbOptions)) {
                var playerController = new PlayerController(doodleApiMoq.Object, context);

                playerController.ModelState.AddModelError("AS","AS");

                var result = playerController.Create(new FootballManager.Models.Player());

                Assert.IsInstanceOf<ViewResult>(result);
            }

        }
    }
}
