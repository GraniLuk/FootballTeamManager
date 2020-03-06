using DoodleApi.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Resources;

namespace DoodleParserTests
{
    [TestFixture]
    public class RootObjectParserTests
    {
        private RootObject _rootObject;
        [SetUp]
        public void ParseRootObject()
        {
            string responseString = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\TestData\\bqsFile.json");


            _rootObject = JsonConvert.DeserializeObject<RootObject>(responseString);
        }

        [Test]
        public void FirstMatch_GetOptions_StartDateEquals2019_9_7()
        {
            var option = _rootObject.options.FirstOrDefault();

            Assert.AreEqual(option.ReadableDate, new DateTime(2019, 10, 9, 18, 30,0));
        }

        [Test]
        public void SecondMatch_GetOptions_StartDateEquals2019_9_7()
        {
            var option = _rootObject.options.Skip(1).FirstOrDefault();

            Assert.AreEqual(option.ReadableDate, new DateTime(2019,10, 16, 18, 30, 0));
        }

        [Test]
        public void ForthMatch_GetOptions_StartDateEquals2019_10_6()
        {
            var option = _rootObject.options.Skip(3).FirstOrDefault();

            Assert.AreEqual(new DateTime(2019, 11, 6, 19, 30, 0), option.ReadableDate);
        }

        [Test]
        public void GetNumberOfMatchWithDate_Returns2()
        {
            var option = _rootObject.CheckPositionDateInArray(new DateTime(2019, 10, 23));

            Assert.AreEqual(2, option);

        }
    }
}
