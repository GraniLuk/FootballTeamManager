using DoodleApi;
using DoodleApi.Model;
using FootballManager.Controllers;
using FootballManager.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballManagerTests.PlayerControllerTests {
    [TestFixture]
    public class DoodleRefreshTests {
        [Test]
        public void DoodleRefresh_UpdatesActiveOnPlayer() {
            var doodleApiMoq = new Mock<IApi>();
            doodleApiMoq.Setup(x => x.GetActivePlayersAt(It.IsAny<DateTime>())).Returns(new List<Participant> { new Participant {
                id = 1,
                name = "LukaszG"
            }
            });
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            using (var context = new ApplicationDbContext(dbOptions)) {
                context.Players.Add(new FootballManager.Models.Player { DoodleName = "LukaszG", Active = false });
                context.SaveChanges();

                var playerController = new PlayerController(doodleApiMoq.Object, context);

                playerController.DoodleRefresh(DateTime.UtcNow);

                Assert.IsTrue(context.Players.Single().Active);
            }



        }
    }
}
