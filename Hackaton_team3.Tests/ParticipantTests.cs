using System;
using NUnit.Framework;

namespace Hackaton_team3.Tests
{
    public class ParticipantTests
    {
        [TestCase("1", Division.Advanced, "1", Division.Advanced)]
        [TestCase("2", Division.Middle, "2", Division.Middle)]
        [TestCase("3", Division.Beginner, "3", Division.Beginner)]
        public void ConstructorTest(string actualName, Division actualDivision, string expectedName, Division expectedDivision)
        {
            Participant actualParticipant = Participant.Create(actualName, actualDivision);

            Assert.AreEqual(expectedName, actualParticipant.Name);
            Assert.AreEqual(expectedDivision, actualParticipant.Division);
        }


        [TestCase("1,Advanced", "1", Division.Advanced)]
        public void SerializerConstructorTest(string line, string expectedName, Division expectedDivision)
        {
            Participant actualPatricipant = Participant.Create(line);
            Participant expectedParticipant = new Participant(expectedName, expectedDivision);

            Assert.AreEqual(expectedParticipant, actualPatricipant);
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

        [TestCase("1", Division.Advanced, "\"1\",\"Advanced\"")]
        public void Serialize_WhenValidTestPassed_ShouldReturnObjectToStringSerialization(string name, Division division, string expected)
        {
            Participant actualPatricipant = new Participant(name, division);
            string actual = actualPatricipant.Serialize();
            Assert.AreEqual(expected, actual);
        }
        [TestCase(null, Division.Advanced)]
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
            Assert.Throws<ArgumentNullException>(() => actual.Name = actualName);
        }
    }
}
