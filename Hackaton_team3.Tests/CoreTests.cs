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
        [TestCase("1")]
        public void SelectParticipantFromToDb_WhemValidTestPassed_ShouldReturnArrayWithTwoParticipants(string matchId)
        {
            Core core = Core.GetCore();

            core.ConnectToTournamntsDatabase();
            string[] actual = core.GetParticipantFromDbByMatch(matchId);

            string[] expected = new string[2];
            expected[0] = "TestName,Middle";
            expected[1] = "TestName,Middle";
            bool actualBool = true;
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    actualBool = false;
                }
            }
            Assert.IsTrue(actualBool);
        }


        [Test]
        public void ConnectDataBase_WhenValidTestPassed_ConnectionwhithoutException()
        {
            Core core = Core.GetCore();

            Assert.IsTrue(core.ConnectToTournamntsDatabase());
        }

        [TestCase(@"'TestName','Middle'")]
        public void InsertParticipantInToDb_WhemValidTestPassed_ShouldAddNewValue(string value)
        {
            Core core = Core.GetCore();

            core.ConnectToTournamntsDatabase();
            core.InsertParticipantInToDb(value);

            
        }
        //[TestCase(null)]
        //public void GetCore_WhenInvalidTestPassed_ShouldReturnAgrumentNullException(string actualString)
        //{
        //    Assert.Throws<ArgumentNullException>(() => Core.GetCore(actualString));
        //}
    }
}
