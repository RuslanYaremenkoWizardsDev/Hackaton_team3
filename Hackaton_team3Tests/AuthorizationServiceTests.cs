using NUnit.Framework;
using System;
using System.Collections.Generic;



namespace Hackaton_team3.Tests
{
    class AuthorizationServiceTests
    {
        [TestCase(null)]
        public void DoesLoginExistTest_ShouldReturnArgumentNullException(string actualEmail)
        {
            Assert.Throws<ArgumentNullException>(() => AuthorizationService.DoesLoginExist(actualEmail));
        }

        [TestCase(null,null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        public void IsPasswordCorrect_ShouldReturnArgumentNullException(string actualEmail, string actualPassword)
        {
            Assert.Throws<ArgumentNullException>(() => AuthorizationService.IsPasswordCorrect(actualEmail, actualPassword));
        }
    }
}
