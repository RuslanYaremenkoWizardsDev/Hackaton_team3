using Hackaton_team3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackaton_team3Tests
{
    class MatchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public void ConstructorTest1()
        {

            Participant participant1 = new Participant("1", Division.Advanced);
            Participant participant2 = new Participant("2", Division.Advanced);
            Participant participant1Expect = new Participant("1", Division.Advanced);
            Participant participant2Expect = new Participant("2", Division.Advanced);
            Match actualMatch = new Match(participant1, participant2);
            Match expectedMatch = new Match(participant1Expect, participant2Expect);
            expectedMatch.Result = "0:0";
            expectedMatch.Status = Status.NotStarted;
            Assert.AreEqual(participant1Expect, participant1);
            Assert.AreEqual(participant2Expect, participant2);
        }

        [Test]

        public void ConstructorTest2()
        {

            Participant participant1 = new Participant("1", Division.Beginner);
            Participant participant2 = new Participant("2", Division.Beginner);
            Participant participant1Expect = new Participant("1", Division.Beginner);
            Participant participant2Expect = new Participant("2", Division.Beginner);
            Match actualMatch = new Match(participant1, participant2);
            Match expectedMatch = new Match(participant1Expect, participant2Expect);
            expectedMatch.Result = "0:0";
            expectedMatch.Status = Status.NotStarted;
            Assert.AreEqual(participant1Expect, participant1);
            Assert.AreEqual(participant2Expect, participant2);
        }

        [Test]

        public void ConstructorTest3()
        {

            Participant participant1 = new Participant("1", Division.Middle);
            Participant participant2 = new Participant("2", Division.Middle);
            Participant participant1Expect = new Participant("1", Division.Middle);
            Participant participant2Expect = new Participant("2", Division.Middle);
            Match actualMatch = new Match(participant1, participant2);
            Match expectedMatch = new Match(participant1Expect, participant2Expect);
            expectedMatch.Result = "0:0";
            expectedMatch.Status = Status.NotStarted;
            Assert.AreEqual(participant1Expect, participant1);
            Assert.AreEqual(participant2Expect, participant2);
        }

        [Test]

        public void EqualsTest1()
        {
            Participant participant1 = new Participant("1", Division.Middle);
            Participant participant2 = new Participant("2", Division.Middle);
            Participant participant1Expect = new Participant("1", Division.Middle);
            Participant participant2Expect = new Participant("2", Division.Middle);
            Match first = new Match(participant1,participant2);
            first.Result = "1:0";
            first.Status = Status.InProgress;
            Match second = new Match(participant1Expect, participant2Expect);
            second.Result = "1:0";
            second.Status = Status.InProgress;
            bool act = second.Equals(first);
            Assert.AreEqual(true, act);
        }

        [Test]

        public void EqualsTest2()
        {
            Participant participant1 = new Participant("1", Division.Middle);
            Participant participant2 = new Participant("2", Division.Middle);
            Participant participant1Expect = new Participant("1", Division.Middle);
            Participant participant2Expect = new Participant("2", Division.Middle);
            Match first = new Match(participant1, participant2);
            first.Result = "2:0";
            first.Status = Status.InProgress;
            Match second = new Match(participant1Expect, participant2Expect);
            second.Result = "1:0";
            second.Status = Status.InProgress;
            bool act = second.Equals(first);
            Assert.AreEqual(false, act);
        }

        [Test]

        public void EqualsTest3()
        {
            Participant participant1 = new Participant("1", Division.Middle);
            Participant participant2 = new Participant("2", Division.Middle);
            Participant participant1Expect = new Participant("1", Division.Middle);
            Participant participant2Expect = new Participant("2", Division.Middle);
            Match first = new Match(participant1, participant2);
            first.Result = "1:0";
            first.Status = Status.InProgress;
            Match second = new Match(participant1Expect, participant2Expect);
            second.Result = "1:0";
            second.Status = Status.Completed;
            bool act = second.Equals(first);
            Assert.AreEqual(false, act);
        }

        [Test]

        public void EqualsTest4()
        {
            Participant participant1 = new Participant("1", Division.Middle);
            Participant participant2 = new Participant("2", Division.Middle);
            Participant participant1Expect = new Participant("2", Division.Middle);
            Participant participant2Expect = new Participant("2", Division.Middle);
            Match first = new Match(participant1, participant2);
            first.Result = "2:0";
            first.Status = Status.InProgress;
            Match second = new Match(participant1Expect, participant2Expect);
            second.Result = "1:0";
            second.Status = Status.InProgress;
            bool act = second.Equals(first);
            Assert.AreEqual(false, act);
        }
    }
}