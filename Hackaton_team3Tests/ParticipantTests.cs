using NUnit.Framework;
using System;

namespace Hackaton_team3.Tests
{
    class ParticipantTests
    {
        [TestCase("1", Division.Advanced, "1", Division.Advanced)]
        [TestCase("2", Division.Middle, "2", Division.Middle)]
        [TestCase("3", Division.Beginner, "3", Division.Beginner)]
        public void ConstructorTest(string actualName, Division actualDivision, string expectedName, Division expectedDivision)
        {
            Participant actualParticipant =  Participant.Create(actualName, actualDivision);

            Assert.AreEqual(expectedName, actualParticipant.Name);
            Assert.AreEqual(expectedDivision, actualParticipant.Division);
        }

        [TestCase("1", Division.Advanced, "1", Division.Advanced, true)]
        [TestCase("1", Division.Advanced, "2", Division.Advanced, false)]
        [TestCase("1", Division.Advanced, "1", Division.Middle, false)]
        public void Equals_WhenValidTestPassed_ShouldRerturnTrueOrFalse(string actualName, Division actualDivision, string expectedName, Division expectedDivision, bool expected)
        {
            Participant actualParticipant = Participant.Create(actualName, actualDivision);
            Participant expectedParticipant = Participant.Create(expectedName, expectedDivision);

            bool actual = actualParticipant.Equals(expectedParticipant);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null,Division.Advanced)]
        [TestCase(null, Division.Beginner)]
        [TestCase(null, Division.Middle)]
        public void Create_WhenInvalidTestPassed_ShouldReturnArgumentNullException(string actualName,
            Division actualDivision)
        {
            Assert.Throws<ArgumentNullException>(() => Participant.Create(actualName, actualDivision));
        }

        [TestCase(null, Division.Advanced)]
        [TestCase(null, Division.Beginner)]
        [TestCase(null, Division.Middle)]
        public void SetName_WhenInvalidTestPassed_ShouldReturnArgumentNullException(string actualName,
            Division actualDivision)
        {
            Participant actual = Participant.Create(string.Empty, actualDivision);
            Assert.Throws<ArgumentNullException>(() =>actual.Name = actualName );
        }
    }
}
