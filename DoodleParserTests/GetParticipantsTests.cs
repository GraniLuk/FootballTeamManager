using DoodleParser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleParserTests
{
    [TestFixture]
    public class ParsingDoodleTests
    {
        private readonly string doodleUrl = "http://doodle.com/api/v2.0/polls/vxmqh3weap4az3cu/";
        [Test]
        public void GetAllParticipants()
        {
            var response = new Client(doodleUrl).GetParticipants().Count;

            Assert.AreEqual(20, response);

        }

        [Test]
        public void GetAllActiveParticipantsForLastWeek()
        {
            var response = new Client(doodleUrl).GetParticipants().Count(x => x.preferences.LastOrDefault() == 1);

            Assert.AreEqual(12, response);
        }

    }
}
