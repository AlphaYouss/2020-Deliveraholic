using System;
using Unit_tests.Containers.Stubs;
using deliveraholic_backend.Models;
using deliveraholic_backend.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_tests.Containers
{
    [TestClass]
    public class AccountContainerTests
    {
        public AccountContainerStubs acs;
        public AccountContainer ac;

        public AccountContainerTests()
        {
            acs = new AccountContainerStubs();
            ac = new AccountContainer(acs);
        }


        /*
        ====================
              ByEmail
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field account and account.email.")]
        public void ByEmailExceptionAccountEmpty()
        {
            Assert.IsNotNull(ac.GetAccount(""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field account and account.email.")]
        public void ByEmailExceptionEmailEmpty()
        {
            acs.account = new Account();
            Assert.IsNotNull(ac.GetAccount(""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field account and account.email.")]
        public void ByEmailFalseDifferentEmail()
        {
            acs.account = new Account();
            Assert.AreEqual(ac.GetAccount(""), acs.account);
        }


        [TestMethod]
        public void ByEmailTrue()
        {
            string email = "mes10@live.nl";

            acs.account = new Account
            {
                email = email
            };

            Assert.AreEqual(ac.GetAccount(email), acs.account);
        }


        /*
        ====================
              ByUserID
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field account and account.accountID.")]
        public void ByUserIDExceptionAccountEmpty()
        {
            Assert.IsNotNull(ac.GetAccount(new Guid()));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field account and account.email.")]
        public void ByUserIDFalseDifferentEmail()
        {
            acs.account = new Account();
            Assert.AreEqual(ac.GetAccount(Guid.NewGuid()), acs.account);
        }


        [TestMethod]
        public void ByUserIDTrue()
        {
            Guid id = Guid.NewGuid();

            acs.account = new Account
            {
                accountID = id
            };

            Assert.AreEqual(ac.GetAccount(id), acs.account);
        }


        [TestMethod]
        public void ByUserIDTrueEmptyID()
        {
            acs.account = new Account();

            Assert.AreEqual(ac.GetAccount(new Guid()), acs.account);
        }


        /*
        ====================
          Change Password
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void ChangePasswordExceptionAccountEmpty()
        {
            Assert.IsNotNull(ac.ChangePassword("", "", "", "", ""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void ChangePasswordExceptionFirstnameEmpty()
        {
            acs.successReturnValue = true;

            Assert.IsNotNull(ac.ChangePassword(null, "", "", "", ""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void ChangePasswordExceptionLastnameEmpty()
        {
            acs.successReturnValue = true;

            Assert.IsNotNull(ac.ChangePassword("", null, "", "", ""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void ChangePasswordExceptionEmailEmpty()
        {
            acs.successReturnValue = true;

            Assert.IsNotNull(ac.ChangePassword("", "", null, "", ""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void ChangePasswordExceptionPasswordEmpty()
        {
            acs.successReturnValue = true;

            Assert.IsNotNull(ac.ChangePassword("", "", "", null, ""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void ChangePasswordExceptionPasswordRepeatEmpty()
        {
            acs.successReturnValue = true;

            Assert.IsNotNull(ac.ChangePassword("", "", "", "", null));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue, the parameters and the same password.")]
        public void ChangePasswordExceptionPasswordRepeatWrong()
        {
            acs.successReturnValue = true;

            Assert.IsNotNull(ac.ChangePassword("Carson", "Alexander", "carson.alexander@gmail.com", "Welkom12345", "Welkom1234"));
        }


        [TestMethod]
        public void ChangePasswordFalse()
        {
            string firstname = "Carson";
            string lastname = "Alexander";
            string email = "mes10@live.nl";
            string password = "Welkom12345";

            acs.successReturnValue = false;

            Assert.IsFalse(ac.ChangePassword(firstname, lastname, email, password, password));
        }


        [TestMethod]
        public void ChangePasswordTrue()
        {
            string firstname = "Carson";
            string lastname = "Alexander";
            string email = "mes10@live.nl";
            string password = "Welkom12345";

            acs.successReturnValue = true;

            Assert.IsTrue(ac.ChangePassword(firstname, lastname, email, password, password));
        }


        /*
        ====================
             Deliverers
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field existReturnValue.")]
        public void DeliverersFalseExceptionNoExistsValue()
        {
            Assert.IsNotNull(ac.GetDeliverers());
        }


        [TestMethod]
        public void DeliverersTrueNotNull()
        {
            acs.existReturnValue = true;

            Assert.IsNotNull(ac.GetDeliverers());
        }


        [TestMethod]
        public void DeliverersTrueReturnCount()
        {
            acs.existReturnValue = true;
            ac.GetDeliverers();

            Assert.AreEqual(0, acs.numberReturnValue);
        }


        /*
        ====================
             EmailExists
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field existReturnValue and email.")]
        public void EmailExistsExceptionNoExistsValue()
        {
            Assert.IsTrue(ac.EmailExists(""));
        }


        [TestMethod]
        public void EmailExistsFalse()
        {
            acs.existReturnValue = false;

            Assert.IsFalse(ac.EmailExists("mes10@live.nl"));
        }


        [TestMethod]
        public void EmailExistsTrue()
        {
            acs.existReturnValue = true;

            Assert.IsTrue(ac.EmailExists("mes10@live.nl"));
        }


        /*
        =======================
        IsValidLoginCredentials
        =======================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void IsValidLoginCredentialsExceptionNoSuccessValue()
        {
            Assert.IsTrue(ac.IsValidLoginCredentials("", ""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void IsValidLoginCredentialsExceptionNoEmail()
        {
            acs.successReturnValue = true;

            Assert.IsTrue(ac.IsValidLoginCredentials(null, ""));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the parameters.")]
        public void IsValidLoginCredentialsExceptionNoPassword()
        {
            acs.successReturnValue = true;

            Assert.IsTrue(ac.IsValidLoginCredentials("", null));
        }


        [TestMethod]
        public void IsValidLoginCredentialsFalse()
        {
            acs.successReturnValue = false;

            Assert.IsFalse(ac.IsValidLoginCredentials("mes10@live.nl", "Welkom12345"));
        }


        [TestMethod]
        public void IsValidLoginCredentialsTrue()
        {
            acs.successReturnValue = true;

            Assert.IsTrue(ac.IsValidLoginCredentials("mes10@live.nl", "Welkom12345"));
        }


        /*
        ====================
              Register
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the account.")]
        public void RegisterExceptionNoSuccessValue()
        {
            Assert.IsNotNull(ac.Register(new Account()));
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field successReturnValue and the account.")]
        public void RegisterExceptionAccountEmpty()
        {
            acs.successReturnValue = true;

            Assert.IsNotNull(ac.Register(null));
        }


        [TestMethod]
        public void RegisterFalse()
        {
            acs.successReturnValue = false;

            Assert.IsFalse(ac.Register(new Account()));
        }


        [TestMethod]
        public void RegisterTrue()
        {
            acs.successReturnValue = true;

            Assert.IsTrue(ac.Register(new Account()));
        }


        /*
        ====================
               Users
        ====================
        */


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid use of stub code. First set field existReturnValue.")]
        public void UsersFalseExceptionNoExistsValue()
        {
            Assert.IsNotNull(ac.GetUsers());
        }


        [TestMethod]
        public void UsersTrueNotNull()
        {
            acs.existReturnValue = true;

            Assert.IsNotNull(ac.GetUsers());
        }


        [TestMethod]
        public void UsersTrueReturnCount()
        {
            acs.existReturnValue = true;
            ac.GetUsers();

            Assert.AreEqual(0, acs.numberReturnValue);
        }
    }
}