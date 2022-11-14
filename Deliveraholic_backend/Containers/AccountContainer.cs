using deliveraholic_backend.Interfaces;
using deliveraholic_backend.Models;
using System;
using System.Collections.Generic;

namespace deliveraholic_backend.Containers
{
    public class AccountContainer
    {
        // Account methods based on the DAL.

        readonly IAccount accountDAL;


        public AccountContainer(IAccount accountDAL)
        {
            this.accountDAL = accountDAL;
        }


        public IEnumerable<Account> GetUsers()
        {
            return accountDAL.Users();
        }


        public IEnumerable<Account> GetDeliverers()
        {
            return accountDAL.Deliverers();
        }


        public bool IsValidLoginCredentials(string email, string password)
        {
            return accountDAL.IsValidLoginCredentials(email, password);
        }


        public bool EmailExists(string email)
        {
            return accountDAL.EmailExists(email);
        }


        public bool Register(Account account)
        {
            return accountDAL.Register(account);
        }

        public bool ChangePassword(
            string firstname, string lastname,
            string email, string password,
            string passwordRepeat)
        {
            return accountDAL.ChangePassword(
                firstname, lastname,
                email, password,
                passwordRepeat);
        }


        public Account GetAccount(string email)
        {
            return accountDAL.ByEmail(email);
        }


        public Account GetAccount(Guid userID)
        {
            return accountDAL.ByUserID(userID);
        }
    }
}