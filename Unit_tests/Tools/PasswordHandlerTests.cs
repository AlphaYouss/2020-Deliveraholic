using System;
using deliveraholic_backend.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests.Tools
{
    [TestClass]
    public class PasswordHandlerTests
    {
        public PasswordHandler ph;
        public string[] passwordData;

        public PasswordHandlerTests()
        {
            ph = new PasswordHandler();
        }


        /*
        ====================
              Generate
        ====================
        */


        [TestMethod]
        public void GenerateSaltAndHashEmpty()
        {
            passwordData = ph.GenerateSaltAndHash("");
            CollectionAssert.AllItemsAreNotNull(passwordData);
        }


        [TestMethod]
        public void GenerateSaltAndHashSmallPasswordSize()
        {
            passwordData = ph.GenerateSaltAndHash("Welkom12345");
            CollectionAssert.AllItemsAreNotNull(passwordData);
        }


        [TestMethod]
        public void GenerateSaltAndHashMediumPasswordSize()
        {
            passwordData = ph.GenerateSaltAndHash("Kamertemperatuur12345");
            CollectionAssert.AllItemsAreNotNull(passwordData);
        }


        [TestMethod]
        public void GenerateSaltAndHashLargePasswordSize()
        {
            passwordData = ph.GenerateSaltAndHash("y360UcfN7fyVHoOmfZGSlMWz9vlfaW0bWR0WAS0R");
            CollectionAssert.AllItemsAreNotNull(passwordData);
        }


        /*
        ====================
               Verify
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Salt is not at least eight bytes.")]
        public void VerifyPasswordFalseSaltException()
        {
            string password = "Welkom12345";

            Assert.IsFalse(ph.VerifyPassword("Salt", password, "Hash"));
        }


        [TestMethod]
        public void VerifyPasswordFalseEmptyPassword()
        {
            string password = "Welkom12345";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsFalse(ph.VerifyPassword(passwordData[1], "", passwordData[0]));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "String reference not set to an instance of a String.")]
        public void VerifyPasswordFalsePasswordNull()
        {
            string password = "Welkom12345";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsFalse(ph.VerifyPassword(passwordData[1], null, passwordData[0]));
        }


        [TestMethod]
        public void VerifyPasswordFalseInvalidHash()
        {
            string password = "Welkom12345";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsFalse(ph.VerifyPassword(passwordData[1], password, "Hash"));
        }


        [TestMethod]
        public void VerifyPasswordFalseWrongPassword()
        {
            string password = "Welkom12345";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsFalse(ph.VerifyPassword(passwordData[1], "Welkom1234", passwordData[0]));
        }


        [TestMethod]
        public void VerifyPasswordTrueLetters()
        {
            string password = "Welkom";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsTrue(ph.VerifyPassword(passwordData[1], password, passwordData[0]));
        }


        [TestMethod]
        public void VerifyPasswordTrueNumbers()
        {
            string password = "12345";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsTrue(ph.VerifyPassword(passwordData[1], password, passwordData[0]));
        }


        [TestMethod]
        public void VerifyPasswordTrueSpecialCharacters()
        {
            string password = "`()-()`";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsTrue(ph.VerifyPassword(passwordData[1], password, passwordData[0]));
        }


        [TestMethod]
        public void VerifyPasswordTrueLettersAndNumbers()
        {
            string password = "Welkom12345";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsTrue(ph.VerifyPassword(passwordData[1], password, passwordData[0]));
        }


        [TestMethod]
        public void VerifyPasswordTrueLettersAndSpecialCharacters()
        {
            string password = "Welkom!@#./|;':[}]{-_+=*&^%#!~`";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsTrue(ph.VerifyPassword(passwordData[1], password, passwordData[0]));
        }


        [TestMethod]
        public void VerifyPasswordTrueNumbersAndSpecialCharacters()
        {
            string password = "!2@4%";
            passwordData = ph.GenerateSaltAndHash(password);

            Assert.IsTrue(ph.VerifyPassword(passwordData[1], password, passwordData[0]));
        }
    }
}