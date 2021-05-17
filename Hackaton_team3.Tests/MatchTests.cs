using System;
using NUnit.Framework;

namespace Hackaton_team3.Tests
{
    public class MatchTests
    {
        [TestCase("Name", Division.Advanced)]
        [TestCase("Name", Division.Beginner)]
        [TestCase("Name", Division.Middle)]
        public void Create_WhenValidTestPassed_ShouldReturnValidMatch(string name, Division division)
        {
            Participant participant = Participant.Create(name, division);
            Match actual = Match.Create(participant, participant);

            Assert.NotNull(actual);
            Assert.NotNull(actual.ParticipantOne);
            Assert.NotNull(actual.ParticipantTwo);
        }

        [TestCase("name1", Division.Advanced, "name1", Division.Advanced, true)]
        [TestCase("name1", Division.Beginner, "name1", Division.Beginner, true)]
        [TestCase("name1", Division.Middle, "name1", Division.Middle, true)]
        [TestCase("name1", Division.Advanced, "name1", Division.Beginner, false)]
        [TestCase("name2", Division.Advanced, "name1", Division.Advanced, false)]
        [TestCase("name2", Division.Beginner, "name1", Division.Advanced, false)]
        public void Equals_WhenValidTestPassed_ShouldReturnTrueOrFalse(string actualName, Division actualDivision,
            string expectedName, Division expectedDivision, bool expected)
        {
            Participant actualParticipant = Participant.Create(actualName, actualDivision);
            Match actualMatch = Match.Create(actualParticipant, actualParticipant);
            Participant expectedParticipant = Participant.Create(expectedName, expectedDivision);
            Match expectedMatch = Match.Create(expectedParticipant, expectedParticipant);

            bool actual = actualMatch.Equals(expectedMatch);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("10:10", "10:10")]
        [TestCase("111", "111")]
        public void SetResult_WhenValidTestPassed_ShouldSetCurrentResult(string actualString, string expected)
        {
            Participant actualParticipant = Participant.Create(string.Empty, Division.Advanced);
            Match actualMatch = Match.Create(actualParticipant, actualParticipant);
            actualMatch.Result = actualString;

            Assert.AreEqual(expected, actualMatch.Result);
        }

        [TestCase(null)]
        public void SetResult_WhenInvalidTestPassed_ShouldReturnArgumentNullException(string actualString)
        {
            Participant actualParticipant = Participant.Create(string.Empty, Division.Advanced);
            Match actualMatch = Match.Create(actualParticipant, actualParticipant);

            Assert.Throws<ArgumentNullException>(() => actualMatch.Result = actualString);
        }

        [TestCase(null)]
        public void SetParitcipant_WhenInvalidTestPassed_ShouldReturnArgumentNullException(Participant actualPaticipant)
        {
            Participant actualParticipant = Participant.Create(string.Empty, Division.Advanced);
            Match actualMatch = Match.Create(actualParticipant, actualParticipant);

            Assert.Throws<ArgumentNullException>(() => actualMatch.ParticipantOne = actualPaticipant);
            Assert.Throws<ArgumentNullException>(() => actualMatch.ParticipantTwo = actualPaticipant);
        }

        [TestCase(null)]
        public void Create_WhenInvalidTestPassed_ShouldReturnArgumentNullException(Participant actualPaticipant)
        {
            Participant actualParticipant = Participant.Create(string.Empty, Division.Advanced);

            Assert.Throws<ArgumentNullException>(() => Match.Create(actualPaticipant, actualParticipant));
            Assert.Throws<ArgumentNullException>(() => Match.Create(actualParticipant, actualPaticipant));
        }
    }
}
