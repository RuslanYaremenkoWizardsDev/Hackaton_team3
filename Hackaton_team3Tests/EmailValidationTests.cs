using NUnit.Framework;
using System;
namespace Hackaton_team3.Tests
{
    public class EmailValidationTests
    {
        public void Setup()
        {
        }

        [TestCase("egorusdnepr@gmail.com", true)]
        [TestCase("andreyzaycev12041961@gmail.com", true)]
        [TestCase("3266880@gmail.com", true)]
        [TestCase("Skochmen@gmail.comiii", false)]
        [TestCase("Step.nst@gmail.com", true)]
        [TestCase("brovko.sasha2002@gmail.com", true)]
        [TestCase("mashayakovenk...o7@gmail.com", false)]
        [TestCase("murashko.konst.andr@gmail.com", true)]
        [TestCase(".murashko.konst.andr@gmail.com", false)]
        [TestCase("murashko.konst.andr.@gmail.com", false)]
        [TestCase("murashko.kons$#t.andr@gmail.com", false)]

        public void EmailCheckTests_CheckIfEmailIsValid(string actualEmail, bool expected)
        {
            bool actual = EmailValidation.CheckEmail(actualEmail);
            

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void EmailCheckTests_ShouldReturnArgumentNullException(string actualEmail)
        {
            Assert.Throws<ArgumentNullException>(() => EmailValidation.CheckEmail(actualEmail));
        }
    }
}
