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

        [TestCase("1", "1,,Tournament,,2020.06.01,2020.05.01,Middle,Bo1,NotStarted")]
        public void SerializeConstructorTest(string actualName,string actualLine)
        {
            Tournament actual = Tournament.Create(actualLine);
            Tournament expected = CreateTournamentForSerializationTest(actualName);

            Assert.That(actual, Is.TypeOf<Tournament>());
            Assert.AreEqual(expected,actual);
        }

        [TestCase(null)]
        public void SerializeConstructorTest_ShouldReturnArgumentNullException(string serializedString)
        {
            Assert.Throws<ArgumentNullException>(() => Tournament.Create(serializedString));
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

        [TestCase("1", "\"1\",\"\",\"Tournament\",\"\",\"2020.06.01\",\"2020.05.01\",\"Middle\",\"Bo1\",\"NotStarted\"")]

        public void Serialize_WhenValidTestPassed_ShouldReturnSerializaedObjectAsText(
                string actualName, string expected
            )
        {
            Tournament actualTournament = CreateTournamentForSerializationTest(actualName);
           
            string actual = actualTournament.Serialize();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        public Tournament CreateTournamentForSerializationTest(string name)
        {
            Tournament actualTournament = new Tournament();
            actualTournament.Name = name;
            actualTournament.Start = new DateTime(2020, 06, 01);
            actualTournament.EndRegistration = new DateTime(2020, 05, 01);
            actualTournament.Mode = TournamentMode.Tournament;
            actualTournament.Description = "";
            actualTournament.Division = Division.Middle;
            actualTournament.Location = "";
            actualTournament.Scenario = Scenario.Bo1;
            actualTournament.Status = Status.NotStarted;

            return actualTournament;
        }

    }
}
