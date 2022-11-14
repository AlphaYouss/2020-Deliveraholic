using deliveraholic_backend.Interfaces;
using deliveraholic_backend.Models;
using deliveraholic_backend.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace deliveraholic_backend.DALs
{
    public class AccountDAL : IAccount
    {
        private DatabaseContext dc { get; set; }
        private PasswordHandler ph { get; set; }


        public AccountDAL(DatabaseContext context)
        {
            // Set database context.

            dc = context;
            ph = new PasswordHandler();
        }


        public IEnumerable<Account> Deliverers()
        {
            // Get deliverers.

            IEnumerable<Account> accounts = dc.accounts.Where(
                account =>
                account.type == AccountType.deliverer
            ).ToArray();

            return accounts;
        }


        public IEnumerable<Account> Users()
        {
            // Get users.

            IEnumerable<Account> accounts = dc.accounts.Where(
                account =>
                account.type == AccountType.user
            ).ToArray();

            return accounts;
        }


        public bool IsValidLoginCredentials(string email, string password)
        {
            // Check if valid login credentials.

            string[] passwordData = new string[2];

            passwordData[0] = GetPassword(email);
            passwordData[1] = GetSalt(email);

            if (ph.VerifyPassword(passwordData[1], password, passwordData[0]))
            {
                return true;
            }
            return false;
        }


        private string GetPassword(string email)
        {
            // Get password hash.

            Account account = dc.accounts.Where(
                account =>
                account.email.ToLower() == email.ToLower()
            ).FirstOrDefault();

            return account.passwordHash;
        }


        private string GetSalt(string email)
        {
            // Get password salt.

            Account account = dc.accounts.Where(
                account =>
                account.email.ToLower() == email.ToLower()
            ).FirstOrDefault();

            return account.passwordSalt;
        }


        public bool EmailExists(string email)
        {
            // Check if email is in DB.

            IEnumerable<Account> accounts = dc.accounts.Where(
                 account =>
                 account.email.ToLower() == email.ToLower()
            ).ToArray();

            if (accounts.Count() == 1)
            {
                return true;
            }
            return false;
        }


        public bool Register(Account account)
        {
            // Create account.

            string[] passwordData = ph.GenerateSaltAndHash(account.passwordHash);

            account.accountID = Guid.NewGuid();
            account.type = AccountType.user;
            account.passwordHash = passwordData[0];
            account.passwordSalt = passwordData[1];
            account.createdAt = DateTime.Now;

            dc.accounts.Add(account);

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool ChangePassword(
            string firstname, string lastname,
            string email, string password,
            string passwordRepeat)
        {
            Account account = dc.accounts.SingleOrDefault(
                a =>
                a.firstName.ToLower() == firstname.ToLower() &&
                a.lastName.ToLower() == lastname.ToLower() &&
                a.email.ToLower() == email.ToLower());
            // Update password.

            if (account != null)
            {

                string[] passwordData = ph.GenerateSaltAndHash(password);

                account.passwordHash = passwordData[0];
                account.passwordSalt = passwordData[1];

                dc.accounts.Update(account);
                dc.SaveChanges();
                return true;
            }
            return false;
        }


        public Account ByEmail(string email)
        {
            Account account = dc.accounts.Where(
                account =>
                account.email.ToLower() == email.ToLower()
            ).FirstOrDefault();

            return account;
        }

        public Account ByUserID(Guid userID)
        {
            Account account = dc.accounts.Where(
                account =>
                account.accountID == userID
            ).FirstOrDefault();

            return account;
        }
    }
}