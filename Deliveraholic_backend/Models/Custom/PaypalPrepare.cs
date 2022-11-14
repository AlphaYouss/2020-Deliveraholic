using PayPal.Api;
using System.Collections.Generic;

namespace deliveraholic_backend.Models.Custom
{
    public class PaypalPrepare
    {
        public Dictionary<string, string> paymentDetails { get; set; }

        public string description { get; set; }

        public string urlCancel { get; set; }
        public string urlReturn { get; set; }


        public PaypalPrepare()
        {
            description = string.Empty;

            urlCancel = string.Empty;
            urlReturn = string.Empty;

            paymentDetails = new Dictionary<string, string>();
        }


        public PayPal.Api.Payment CreatePayment(string id, string secret)
        {
            PayPalConfiguration payPalConfiguration = new PayPalConfiguration(id, secret);
            APIContext apiContext = payPalConfiguration.GetAPIContext();

            PayPal.Api.Payment payment = new PayPal.Api.Payment()
            {
                intent = "sale",
                payer = new Payer() { payment_method = "paypal" },
                transactions = GetTransactionsList(),
                redirect_urls = GetReturnUrls(),
            };
            return payment.Create(apiContext);
        }


        private List<Transaction> GetTransactionsList()
        {
            List<Transaction> transactionList = new List<Transaction>
            {
                new Transaction()
                {
                    description = description,
                    amount = new Amount()
                    {
                        currency = "EUR",
                        total = paymentDetails["Total"],
                        details = new Details()
                        {
                            subtotal = paymentDetails["Total"]
                        }
                    }
                }
            };
            return transactionList;
        }


        private RedirectUrls GetReturnUrls()
        {
            return new RedirectUrls()
            {
                cancel_url = urlCancel,
                return_url = urlReturn
            };
        }
    }
}