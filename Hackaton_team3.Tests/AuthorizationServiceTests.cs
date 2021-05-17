using System;
using NUnit.Framework;

namespace Hackaton_team3.Tests
{
    class AuthorizationServiceTests
    {
        [TestCase(null)]
        public void DoesLoginExistTest_ShouldReturnArgumentNullException(string actualEmail)
        {
            Assert.Throws<ArgumentNullException>(() => AuthorizationService.DoesLoginExist(actualEmail));
        }

        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        public void IsPasswordCorrect_ShouldReturnArgumentNullException(string actualEmail, string actualPassword)
        {
            Assert.Throws<ArgumentNullException>(() => AuthorizationService.IsPasswordCorrect(actualEmail, actualPassword));
        }

        [TestCase("egorusdnepr@gmail.com",true)]
        [TestCase("egorusdnepr2@gmail.com", false)]
        public void DoesLoginExist_ShoulReturnTrueOrFalse(string login, bool expected)
        {
            bool actual = AuthorizationService.DoesLoginExist(login);
            Assert.AreEqual(expected,actual);
        }
    }
}
