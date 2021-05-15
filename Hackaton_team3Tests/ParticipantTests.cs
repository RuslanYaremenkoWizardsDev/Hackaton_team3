using NUnit.Framework;

namespace Hackaton_team3.Tests
{
    class ParticipantTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]//new Participant("Max", Division.Beginner), new Participant("Max", Division.Beginner), true
        public void ConstructorTest()
        {
            Participant first = new Participant("Max", Division.Beginner);
            Assert.AreEqual("Max", first.Name);
            Assert.AreEqual(Division.Beginner, first.Division);
            
           
        }

        [Test]//new Participant("Max", Division.Beginner), new Participant("Max", Division.Beginner), true
        public void EqualsTest1()
        {
            Participant first = new Participant("Max", Division.Beginner);
            Participant second = new Participant("Max", Division.Beginner);
            bool act = first.Equals(second);
            Assert.AreEqual(true, act);
        }

        [Test]//new Participant("Max", Division.Beginner), new Participant("Max", Division.Beginner), true
        public void EqualsTest2()
        {
            Participant first = new Participant("Max", Division.Beginner);
            Participant second = new Participant("Payne", Division.Advanced);
            bool act = first.Equals(second);
            Assert.AreEqual(false, act);
        }


    }
}
