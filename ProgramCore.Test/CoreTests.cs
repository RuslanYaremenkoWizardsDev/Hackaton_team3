using System;
using NUnit.Framework;

namespace ProgramCore.Test
{
    public class Tests
    {
        [TestCase("Data Source=DESKTOP-2SAV0E8;Initial Catalog=Hackaton_team3;Integrated Security=True")]
        [TestCase(null)]
        public void GetCore_WhenValidTestPassed_ShouldReturnCoreObject(string actualString)
        {
            Core actual = null;
            if (actualString == null)
            {
                actual = Core.GetCore();
            }
            else
            {
                actual = Core.GetCore(actualString);
            }

            Assert.NotNull(actual);
        }

        [Test]
        public void ConnectDataBase_WhenValidTestPassed_ConnectionwhithoutException()
        {
            Core core = Core.GetCore();

            Assert.IsTrue(core.ConnectDataBase());
        }

        [TestCase(null)]
        public void GetCore_WhenInvalidTestPassed_ShouldReturnAgrumentNullException(string actualString)
        {
            Assert.Throws<ArgumentNullException>(() => Core.GetCore(actualString));
        }
    }
}