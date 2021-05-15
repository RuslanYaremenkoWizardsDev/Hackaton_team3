using NUnit.Framework;

namespace TestLibrary.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCore_WhenValidTestPassed_ShouldReturnCoreObject()
        {
            Class1 core = Class1.GetCore();

            bool actual = core != null;

            Assert.IsTrue(actual);
        }
    }
}