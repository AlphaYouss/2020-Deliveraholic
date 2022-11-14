using deliveraholic_backend.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests.Tools
{
    [TestClass]
    public class ValidateHandlerTests
    {
        public ValidateHandler vh;

        public ValidateHandlerTests()
        {
            vh = new ValidateHandler();
        }


        /*
        ====================
               Names
        ====================
        */


        [TestMethod]
        public void ValidateNamesFalseLengthShort()
        {
            Assert.IsFalse(vh.ValidateNames("L"));
        }


        [TestMethod]
        public void ValidateNamesFalseLengthLong()
        {
            Assert.IsFalse(vh.ValidateNames("LoremIpsumissimplydummytextoftheprintingandtypesettingindustryLoremIpsumhasbeentheindustrysstandarddummytexteversincethe1500swhenanunknownprintertookagalleyoftypeandscrambledittomakeatypespecimenbook"));
        }


        [TestMethod]
        public void ValidateNamesFalseSpecialCharacters()
        {
            Assert.IsFalse(vh.ValidateNames("Renée"));
        }


        [TestMethod]
        public void ValidateNamesFalseNumbers()
        {
            Assert.IsFalse(vh.ValidateNames("12345"));
        }


        [TestMethod]
        public void ValidateNamesFalseNumbersInName()
        {
            Assert.IsFalse(vh.ValidateNames("T1mmy"));
        }


        [TestMethod]
        public void ValidateNamesTrue()
        {
            Assert.IsTrue(vh.ValidateNames("Timmy"));
        }


        /*
        ====================
               Email
        ====================
        */


        [TestMethod]
        public void ValidateEmailFalseNoAtSign()
        {
            Assert.IsFalse(vh.ValidateEmail("timmy.carson"));
        }


        [TestMethod]
        public void ValidateEmailFalseNoProvider()
        {
            Assert.IsFalse(vh.ValidateEmail("timmy.carson@"));
        }


        [TestMethod]
        public void ValidateEmailFalseNoDomain()
        {
            Assert.IsFalse(vh.ValidateEmail("timmy.carson@gmail"));
        }


        [TestMethod]
        public void ValidateEmailFalseWithSpecialCharacters()
        {
            Assert.IsFalse(vh.ValidateEmail("t!mmy.carson@gmail.com"));
        }


        [TestMethod]
        public void ValidateEmailFalseLongDomein()
        {
            Assert.IsFalse(vh.ValidateEmail("timmy.carson@gmail.outlooook"));
        }


        [TestMethod]
        public void ValidateEmailTrue()
        {
            Assert.IsTrue(vh.ValidateEmail("timmy.carson@gmail.com"));
        }


        [TestMethod]
        public void ValidateEmailTrueWithNumbers()
        {
            Assert.IsTrue(vh.ValidateEmail("t1mmy.cars0n@gmail.com"));
        }


        [TestMethod]
        public void ValidateEmailTrueLongEmail()
        {
            Assert.IsTrue(vh.ValidateEmail("timmyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy.carson@gmail.com"));
        }


        [TestMethod]
        public void ValidateEmailTrueLongProvider()
        {
            Assert.IsTrue(vh.ValidateEmail("timmy.carson@gmaillllllllllllllllllllllllllllllllll.com"));
        }


        /*
        ====================
              Password
        ====================
        */


        [TestMethod]
        public void ValidatePasswordFalseLengthShort()
        {
            Assert.IsFalse(vh.ValidatePassword("Welkom"));
        }


        [TestMethod]
        public void ValidatePasswordFalseNoNumbers()
        {
            Assert.IsFalse(vh.ValidatePassword("Kamertemperatuur"));
        }


        [TestMethod]
        public void ValidatePasswordFalseNoCapitalLetter()
        {
            Assert.IsFalse(vh.ValidatePassword("kamertemperatuur12345"));
        }


        [TestMethod]
        public void ValidatePasswordFalseNoLetters()
        {
            Assert.IsFalse(vh.ValidatePassword("1234567890"));
        }


        [TestMethod]
        public void ValidatePasswordTrue()
        {
            Assert.IsTrue(vh.ValidatePassword("Welkom12345"));
        }


        /*
        ====================
            Phonenumber
        ====================
        */


        [TestMethod]
        public void ValidatePhonenumberFalseInternationalNoPlusSign()
        {
            Assert.IsFalse(vh.ValidatePhonenumber("31651553825"));
        }


        [TestMethod]
        public void ValidatePhonenumberFalseInternationalNumberMissing()
        {
            Assert.IsFalse(vh.ValidatePhonenumber("+3165155382"));
        }


        [TestMethod]
        public void ValidatePhonenumberFalseInternationalTooLong()
        {
            Assert.IsFalse(vh.ValidatePhonenumber("+3165155382555"));
        }


        [TestMethod]
        public void ValidatePhonenumberFalseNumberMissing()
        {
            Assert.IsFalse(vh.ValidatePhonenumber("065155382"));
        }


        [TestMethod]
        public void ValidatePhonenumberFalseTooLong()
        {
            Assert.IsFalse(vh.ValidatePhonenumber("065155382555"));
        }


        [TestMethod]
        public void ValidatePhonenumberFalseLetters()
        {
            Assert.IsFalse(vh.ValidatePhonenumber("065i55E825"));
        }


        [TestMethod]
        public void ValidatePhonenumberFalseSpecialCharacters()
        {
            Assert.IsFalse(vh.ValidatePhonenumber("06-5!553825"));
        }


        [TestMethod]
        public void ValidatePhonenumberTrueInternationalWithDash()
        {
            Assert.IsTrue(vh.ValidatePhonenumber("+316-51553825"));
        }


        [TestMethod]
        public void ValidatePhonenumberTrueInternationalWithoutDash()
        {
            Assert.IsTrue(vh.ValidatePhonenumber("+31651553825"));
        }


        [TestMethod]
        public void ValidatePhonenumberTrueInternationalWithSpace()
        {
            Assert.IsTrue(vh.ValidatePhonenumber("+316 51553825"));
        }


        [TestMethod]
        public void ValidatePhonenumberTrueNoDash()
        {
            Assert.IsTrue(vh.ValidatePhonenumber("0651553825"));
        }


        [TestMethod]
        public void ValidatePhonenumberTrueDash()
        {
            Assert.IsTrue(vh.ValidatePhonenumber("06-51553825"));
        }


        [TestMethod]
        public void ValidatePhonenumberTrueWithSpace()
        {
            Assert.IsTrue(vh.ValidatePhonenumber("06 51553825"));
        }
    }
}