using Hackaton_team3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackaton_team3Tests
{
    class ParticipantTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1", Division.Advanced, "1", Division.Advanced)]
        [TestCase("2", Division.Middle, "2", Division.Middle)]
        [TestCase("3", Division.Beginner, "3", Division.Beginner)]
        public void ConstructorTest(string actualName, Division actualDivision, string expectedName, Division expectedDivision)
        {
            Participant actualParticipant = new Participant(actualName, actualDivision);
            Assert.AreEqual(expectedName, actualParticipant.Name);
            Assert.AreEqual(expectedDivision, actualParticipant.Division);
            
           
        }

        [TestCase("1", Division.Advanced, "1", Division.Advanced, true)]
        [TestCase("1", Division.Advanced, "2", Division.Advanced, false)]
        [TestCase("1", Division.Advanced, "1", Division.Middle, false)]
        public void Equals_WhenValidTestPassed_ShouldRerturnTrueOrFalse(string actualName, Division actualDivision, string expectedName, Division expectedDivision, bool expected)
        {
            Participant actualParticipant = new Participant(actualName, actualDivision);
            Participant expectedParticipant = new Participant(expectedName, expectedDivision);

            bool actual = actualParticipant.Equals(expectedParticipant);

            Assert.AreEqual(expected, actual);
        }


    }
}
