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

        [TestCase("1", 2021, 09, 05, 2021, 09, 01)]
        [TestCase("2", 2021, 01, 02, 2021, 01, 01)]
        public void ConstructorTest(string name, int yearStart, int monthStart, int dayStart, int yearEnd, int monthEnd, int dayEnd)
        {
            Tournament test = new Tournament(name, new DateTime(yearStart, monthStart, dayStart), new DateTime(yearEnd, monthEnd, dayEnd));
            Assert.That(test, Is.TypeOf<Tournament>());
            Assert.AreEqual(name, test.Name);
            Assert.AreEqual(new DateTime(yearStart, monthStart, dayStart), test.Start);
            Assert.AreEqual(new DateTime(yearEnd, monthEnd, dayEnd), test.EndRegistration);
        }

        [TestCase("1", 2021,05,15,2021,05,01,"1",2021,05,15,2021,05,01, true)]
        [TestCase("1", 2021, 05, 15, 2021, 05, 01, "2", 2021, 05, 15, 2021, 05, 01, false)]
        [TestCase("1", 2021, 05, 15, 2021, 05, 01, "1", 2022, 05, 15, 2021, 05, 01, false)]
        public void Equals_WhenValidTestPassed_ShouldRerturnTrueOrFalse(string actualName, int actualStartYear, int actualStartMonth, int actuaStartlDay, int actualEndYear, int actualEndMonth, int actuaEndlDay, string expectedName, int expectedStartYear, int expectedStartMonth, int expectedStartDay, int expectedEndYear, int expectedEndMonth, int expectedEndDay, bool expected)
        {
            Tournament actualParticipant = new Tournament(actualName, new DateTime(actualStartYear, actualStartMonth, actuaStartlDay),new DateTime(actualEndYear, actualEndMonth, actuaEndlDay));
            Tournament expectedParticipant = new Tournament(expectedName, new DateTime(expectedStartYear, expectedStartMonth, expectedStartDay), new DateTime(expectedEndYear, expectedEndMonth, expectedEndDay));

            bool actual = actualParticipant.Equals(expectedParticipant);

            Assert.AreEqual(expected, actual);
        }
    }
}
