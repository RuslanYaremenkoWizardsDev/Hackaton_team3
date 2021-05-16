using NUnit.Framework;
using System.Collections.Generic;

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

            core.ConnectDataBase();
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

            Assert.IsTrue(core.ConnectDataBase());
        }

        [Test]
        public void TemporaryTestRemoveLater()
        {
            Core core = Core.GetCore();
            core.Innitialize();
        }

        [TestCase(@"'TestName','Middle'")]
        public void InsertParticipantInToDb_WhemValidTestPassed_ShouldAddNewValue(string value)
        {
            Core core = Core.GetCore();

            core.ConnectDataBase();
            core.InsertParticipantInToDb(value);   
        }

        [TestCase(@"'1','','Tournament','','2020.06.01','2020.05.01','Middle','Bo1','NotStarted'")]
        public void InsertTournamentToDB_WhenValidTestPassed_ShouldAddNewValue(string value)
        {
            Core core = Core.GetCore();
            core.ConnectDataBase();
            core.InsertTournamentDb(value);
        }

        [TestCase(@"")]
        public void InsertMatchToDB_WhenValidTestPassed_ShouldAddNewValue(string value)
        {
            Core core = Core.GetCore();
            core.ConnectDataBase();
            core.InsertMatchDb(value);
        }

        [TestCase()]
        public void SelectTournamentsFromToDb_WhemValidTestPassed_ShouldReturnListOfTournaments()
        {
            Core core = Core.GetCore();
            core.ConnectDataBase();

            List<string> serializedTournaments = core.GetSerializedtournamentsFromDB();
 
            Assert.IsTrue(serializedTournaments.Count>0);
        }


        [TestCase("2")]
        public void SelectMatchFromToDb_WhemValidTestPassed_ShouldReturnListOfMatch(string tournamentId)
        {
            Core core = Core.GetCore();
            core.ConnectDataBase();

            List<string> serializedMatches = core.GetSerializedMatchesByTournamentFromDB(tournamentId);

            Assert.IsTrue(serializedMatches.Count > 0);
        }
        //[TestCase(null)]
        //public void GetCore_WhenInvalidTestPassed_ShouldReturnAgrumentNullException(string actualString)
        //{
        //    Assert.Throws<ArgumentNullException>(() => Core.GetCore(actualString));
        //}
    }
}
