using deliveraholic_backend.Models;
using System;
using System.Collections.Generic;

namespace deliveraholic_backend.Interfaces
{
    public interface IAccount
    {
        // Account methods:

        IEnumerable<Account> Users();
        IEnumerable<Account> Deliverers();
        bool EmailExists(string email);
        bool Register(Account account);
        bool IsValidLoginCredentials(string email, string password);
        bool ChangePassword(
            string firstname, string lastname,
            string email, string password,
            string passwordRepeat);
        Account ByEmail(string email);
        Account ByUserID(Guid userID);
    }
}