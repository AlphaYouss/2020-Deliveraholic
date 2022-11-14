using System;
using System.Collections.Generic;
using deliveraholic_backend.Models;
using deliveraholic_backend.Interfaces;

namespace Unit_tests.Containers.Stubs
{
    public class AccountContainerStubs : IAccount
    {
        public Account account;
        public bool? existReturnValue = null;
        public bool? successReturnValue = null;
        public string stringReturnValue = null;
        public int numberReturnValue;


        public Account ByEmail(string email)
        {
            if (account == null || account.email != email)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field account and account.email.");
            }
            return account;
        }

        public Account ByUserID(Guid userID)
        {
            if (account == null || account.accountID != userID)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field account and account.accountID.");
            }
            return account;
        }

        public bool ChangePassword(
            string firstname, string lastname,
            string email, string password,
            string passwordRepeat)
        {
            if (
                successReturnValue == null || firstname == "" || 
                lastname == "" || email == "" ||
                password == "" || passwordRepeat == "" ||
                password != passwordRepeat)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field successReturnValue, the parameters and the same password.");
            }
            return successReturnValue.Value;
        }

        public IEnumerable<Account> Deliverers()
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existReturnValue.");
            }

            Stack<Account> accounts = new Stack<Account>();
            numberReturnValue = accounts.Count;

            return accounts;
        }

        public bool EmailExists(string email)
        {
            if (existReturnValue == null || email == "")
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existReturnValue and email.");
            }
            return existReturnValue.Value;
        }

        public bool IsValidLoginCredentials(string email, string password)
        {
            if (
                successReturnValue == null || email == "" ||
                password == "")
            {
                throw new NullReferenceException("Invalid use of stub code. First set field successReturnValue and the parameters.");
            }
            return successReturnValue.Value;
        }

        public bool Register(Account account)
        {
            if (successReturnValue == null || account == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field successReturnValue and the account.");
            }
            return successReturnValue.Value;
        }

        public IEnumerable<Account> Users()
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existReturnValue.");
            }

            Stack<Account> accounts = new Stack<Account>();
            numberReturnValue = accounts.Count;

            return accounts;
        }
    }
}