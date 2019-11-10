using DoodleApi.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Assert.AreEqual(option.ReadableDate, new DateTime(2019, 9, 3, 17, 30,0));
        }

        [Test]
        public void SecondMatch_GetOptions_StartDateEquals2019_9_7()
        {
            var option = _rootObject.options.Skip(1).FirstOrDefault();

            Assert.AreEqual(option.ReadableDate, new DateTime(2019, 9, 10, 17, 30, 0));
        }
    }
}
