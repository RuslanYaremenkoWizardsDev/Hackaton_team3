using NUnit.Framework;

namespace Hackaton_team3.Tests
{
    public class CoreTests
    {
        //[TestCase("Data Source=DESKTOP-2SAV0E8;Initial Catalog=Hackaton_team3;Integrated Security=True")]
        //[TestCase(null)]
        //public void GetCore_WhenValidTestPassed_ShouldReturnCoreObject(string actualString)
        //{
        //    Core actual = null;
        //    if (actualString == null)
        //    {
        //        actual = Core.GetCore();
        //    }
        //    else
        //    {
        //        actual = Core.GetCore(actualString);
        //    }

        //    Assert.NotNull(actual);
        //}

        [Test]
        public void ConnectDataBase_WhenValidTestPassed_ConnectionwhithoutException()
        {
            Core core = Core.GetCore();

            Assert.IsTrue(core.ConnectDataBase());
        }

        [TestCase(@"'TestName','Middle'")]
        public void InsertParticipantInToDb_WhemValidTestPassed_ShouldAddNewValue(string value)
        {
            Core core = Core.GetCore();

            core.ConnectDataBase();
            core.InsertParticipantInToDb(value);

            
        }
        //[TestCase(null)]
        //public void GetCore_WhenInvalidTestPassed_ShouldReturnAgrumentNullException(string actualString)
        //{
        //    Assert.Throws<ArgumentNullException>(() => Core.GetCore(actualString));
        //}
    }
}
