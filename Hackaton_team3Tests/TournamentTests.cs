using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackaton_team3.Tests
{
    class TournamentTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void ConstructorTest(string name, DateTime start, DateTime end)
        {
            Tournament test = new Tournament(name, start, end);
            Assert.That(test, Is.TypeOf<Tournament>());
            Assert.AreEqual(name, test.Name);
            Assert.AreEqual(start, test.Start);
            Assert.AreEqual(end, test.EndRegistration);
        }

       
    }
}
