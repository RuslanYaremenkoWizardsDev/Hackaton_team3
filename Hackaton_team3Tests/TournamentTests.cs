using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackaton_team3.Tests
{
    class TournamentTests
    {
        [TestCase("1", 2021, 09, 05, 2021, 09, 01)]
        [TestCase("2", 2021, 01, 02, 2021, 01, 01)]
        public void Create_WhenValidTestPassed_ShouldReturnTournamentObject(string name, int yearStart, int monthStart, int dayStart, int yearEnd, int monthEnd, int dayEnd)
        {
            Tournament test = Tournament.Create(name, new DateTime(yearStart, monthStart, dayStart), new DateTime(yearEnd, monthEnd, dayEnd));

            Assert.That(test, Is.TypeOf<Tournament>());
            Assert.AreEqual(name, test.Name);
            Assert.AreEqual(new DateTime(yearStart, monthStart, dayStart), test.Start);
            Assert.AreEqual(new DateTime(yearEnd, monthEnd, dayEnd), test.EndRegistration);
        }

        public void SerializeConstructorTest_ShouldReturnArgumentNullException(string serializedString)
        {
            Assert.Throws<ArgumentNullException>(() => Tournament.Create(serializedString));
        }
        [TestCase(null)]
        [TestCase("1", "1,,Tournament,,2020.06.01,2020.05.01,Middle,Bo1,NotStarted")]
        public void SerializeConstructorTest(string actualName,string actualLine)
        {
            Tournament actual = Tournament.Create(actualLine);
            Tournament expected = CreateTournamentForSerializationTest(actualName);

            Assert.That(actual, Is.TypeOf<Tournament>());
            Assert.AreEqual(expected,actual);
        }
        [TestCase(null)]
        public void Create_WhenInvalidTestPassed_ShouldReturnArgumentNullExeption(string actualName)
        {
            Assert.Throws<ArgumentNullException>(() => Tournament.Create(actualName, new DateTime(), new DateTime()));
        }

        [TestCase("1", "1", true)]
        [TestCase("1", "2", false)]
        public void Equals_WhenValidTestPassed_ShouldRerturnTrueOrFalse(string actualName, string expectedName, bool expected)
        {
            Tournament actualParticipant = Tournament.Create(actualName, new DateTime(), new DateTime());
            Tournament expectedParticipant = Tournament.Create(expectedName, new DateTime(), new DateTime());

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


        [TestCase(null)]
        public void SetName_WhenInvalidTestPassed_ShouldReturnArgumentNullExeption(string actualName)
        {
            Tournament actualTournament = Tournament.Create("", DateTime.Now, DateTime.Now);

            Assert.Throws<ArgumentNullException>(() => actualTournament.Name = actualName);
        }

        [Test]
        public void GetLocation_WhenValidTestPassed_ShouldReturnCurrentLocation()
        {
            Tournament actualTournament = Tournament.Create("", DateTime.Now, DateTime.Now);

            Assert.NotNull(actualTournament.Location);
        }

        [TestCase(null)]
        public void SetLocation_WhenInvalidTestPassed_ShouldReturnArgumentNullExeption(string actualLocation)
        {
            Tournament actualTournament = Tournament.Create("", DateTime.Now, DateTime.Now);

            Assert.Throws<ArgumentNullException>(() => actualTournament.Location = actualLocation);
        }


        [Test]
        public void GetPoints_WhenValidTestPassed_ShouldReturnCurrentLocation()
        {
            Tournament actualTournament = Tournament.Create("", DateTime.Now, DateTime.Now);

            Assert.NotNull(actualTournament.Points);
        }

        [TestCase(null)]
        public void SetDescription_WhenInvalidTestPassed_ShouldReturnArgumentNullExeption(string actualDescription)
        {
            Tournament actualTournament = Tournament.Create("", DateTime.Now, DateTime.Now);

            Assert.Throws<ArgumentNullException>(() => actualTournament.Description = actualDescription);
        }

        [TestCase("1234")]
        [TestCase("")]
        [TestCase("!^@&182204497(*@&")]
        public void SetDescription_WhenValidTestPassed_ShouldReturnDescription(string expected)
        {
            Tournament actualTournament = Tournament.Create("", DateTime.Now, DateTime.Now);
            actualTournament.Description = expected;

            string actual = actualTournament.Description;

            Assert.AreEqual(expected, actual);
        }
    }
}
