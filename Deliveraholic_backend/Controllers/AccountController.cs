using deliveraholic_backend.Containers;
using deliveraholic_backend.DALs;
using deliveraholic_backend.Models;
using deliveraholic_backend.Tools;
using Microsoft.AspNetCore.Mvc;
using System;

namespace deliveraholic_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        private AccountContainer ac { get; set; }
        private ValidateHandler vh { get; set; }

        private static Account currentAccount { get; set; }

        private string errorMessage { get; set; }


        public AccountController(DatabaseContext context)
        {
            // Set container & handler.

            vh = new ValidateHandler();
            ac = new AccountContainer(new AccountDAL(context));
        }


        //// [ALL TYPES OF ACCOUNTS] ////


        [Route("users")]
        [HttpGet]
        public IActionResult AllUsers()
        {
            // Return all users:

            return Ok(ac.GetUsers());
        }


        [Route("deliverers")]
        [HttpGet]
        public IActionResult AllDeliverers()
        {
            // Return all deliverers:

            return Ok(ac.GetDeliverers());
        }


        //// [REGISTER] ////


        [Route("register/user")]
        [HttpPost]
        public IActionResult RegisterUser([FromBody] Account account)
        {
            // Register user:

            if (Register(account, AccountType.user) == string.Empty)
            {
                // Register successfull.

                return Created(new Uri("http://localhost:3000/register"), "Succesvol geregistreerd!");
            }
            return Conflict(errorMessage);
        }


        [Route("register/deliverer")]
        [HttpPost]
        public IActionResult RegisterDeliverer([FromBody] Account account)
        {
            // Register deliverer:

            if (Register(account, AccountType.deliverer) == string.Empty)
            {
                // Register successfull.

                return Created(new Uri("http://localhost:3000/register/deliverer"), "Succesvol geregistreerd!");
            }
            return Conflict(errorMessage);
        }


        private string Register(Account account, AccountType accountType)
        {
            //Register:

            account.type = accountType;

            if (IsValidRegister(account) == string.Empty)
            {
                // Valid register.

                if (!ac.Register(account))
                {
                    // Register failed.

                    errorMessage = "Registreren mislukt, probeer het opnieuw.";
                    return errorMessage;
                }
                return string.Empty;
            }
            return errorMessage;
        }


        private string IsValidRegister(Account account)
        {
            // Check userinput:

            if (!vh.ValidateNames(account.firstName))
            {
                // Firstname error.

                errorMessage = "Voer een geldige voornaam in.";
                return errorMessage;
            }
            else if (!vh.ValidateNames(account.lastName))
            {
                // Lastname error.

                errorMessage = "Voer een geldige achternaam in.";
                return errorMessage;
            }
            else if (!vh.ValidatePhonenumber(account.phoneNumber))
            {
                // Phonenumber error.

                errorMessage = "Vul a.u.b. een geldig telefoonnummer in.";
                return errorMessage;
            }
            else if (!vh.ValidatePassword(account.passwordHash))
            {
                // Password error.

                errorMessage = "Vul een sterk wachtwoord in dat hoofdletters en cijfers bevat(minimaal 8 tekens).";
                return errorMessage;
            }
            else if (!vh.ValidateEmail(account.email))
            {
                // Email error.

                errorMessage = "Vul een geldig e-mailadres in.";
                return errorMessage;
            }
            else if (ac.EmailExists(account.email))
            {
                // Email exists.

                errorMessage = "De e-mailadres is al in gebruik.";
                return errorMessage;
            }
            return string.Empty;
        }


        //// [LOGIN] ////


        [Route("login")]
        [HttpPost]
        public IActionResult LoginAccount([FromForm] string email, [FromForm] string password)
        {
            // Login:

            if (IsValidLogin(email, password) == string.Empty)
            {
                // Login successfull.

                return Ok("Inloggen succesvol!");
            }
            return Conflict(errorMessage);
        }


        private string IsValidLogin(string email, string password)
        {
            // Check userinput:

            if (!ac.EmailExists(email))
            {
                // Email error.

                errorMessage = "De e-mailadres bestaat niet.";
                return errorMessage;
            }
            else if (!ac.IsValidLoginCredentials(email, password))
            {
                // Password error.

                errorMessage = "Wachtwoord komt niet overeen!";
                return errorMessage;
            }
            return string.Empty;
        }


        //// [FORGOT PASSWORD] ////


        [Route("forgot-password")]
        [HttpPut]
        public IActionResult UpdatePassword(
            [FromForm] string firstname, [FromForm] string lastname,
            [FromForm] string email, [FromForm] string password,
            [FromForm] string passwordRepeat)
        {
            // Forgot-password:

            if (IsValidForgotPassword(
                firstname, lastname,
                email, password,
                passwordRepeat) == string.Empty)
            {
                // Forgot-password check successfull.

                if (!ac.ChangePassword(
                    firstname, lastname,
                    email, password,
                    passwordRepeat))
                {
                    // Change password failed.

                    errorMessage = "Wachtwoord updaten mislukt, controleer de gegevens en probeer het opnieuw.";
                    return Conflict(errorMessage);
                }
                return Ok("Wachtwoord veranderd!");
            }
            return Conflict(errorMessage);
        }


        private string IsValidForgotPassword(
            string firstname, string lastname,
            string email, string password,
            string passwordRepeat)
        {
            // Check userinput:

            if (!vh.ValidateNames(firstname))
            {
                // Firstname error.

                errorMessage = "Voer een geldige voornaam in.";
                return errorMessage;
            }
            else if (!vh.ValidateNames(lastname))
            {
                // Lastname error.

                errorMessage = "Voer een geldige achternaam in.";
                return errorMessage;
            }
            else if (!vh.ValidateEmail(email))
            {
                // Email error.

                errorMessage = "Vul een geldig e-mailadres in.";
                return errorMessage;
            }
            else if (!ac.EmailExists(email))
            {
                // Email exists.

                errorMessage = "De e-mailadres is bestaat niet.";
                return errorMessage;
            }
            else if (!vh.ValidatePassword(password))
            {
                // Password error.

                errorMessage = "Vul een sterk wachtwoord in dat hoofdletters en cijfers bevat(minimaal 8 tekens).";
                return errorMessage;
            }
            else if (password != passwordRepeat)
            {
                // Password error.

                errorMessage = "Wachtwoorden komen niet overeen.";
                return errorMessage;
            }
            return string.Empty;
        }

        //// [ACCOUNTDETAILS] ////


        [Route("byemail/{email}")]
        [HttpGet]
        public IActionResult GetAccountDetailsByEmail([FromQuery] string email)
        {
            // Get userdetails by email:

            Account account = ac.GetAccount(email);

            if (CheckAccount(account) == string.Empty)
            {
                // Account exists.

                return Ok(currentAccount);
            }
            return NotFound(errorMessage);
        }


        [Route("byid/{userID}")]
        [HttpGet]
        public IActionResult GetAccountDetailsByID([FromQuery] string userID)
        {
            // Get userdetails by ID:

            Guid userGuid = new Guid(userID);
            Account account = ac.GetAccount(userGuid);

            if (CheckAccount(account) == string.Empty)
            {
                // Account exists.

                return Ok(currentAccount);
            }
            return NotFound(errorMessage);
        }


        private string CheckAccount(Account account)
        {
            // Check if account exists:

            if (account != null)
            {
                // Set currentaccount.

                currentAccount = account;
                return string.Empty;
            }
            errorMessage = "Geen gebruiker gevonden.";
            return errorMessage;
        }
    }
}