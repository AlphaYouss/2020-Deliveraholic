using System;

namespace PayPal_Demo.paypal
{
    public partial class PaymentStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPaymentStart_Click(object sender, EventArgs e)
        {
            PaymentDetails pd = new PaymentDetails();
            pd.Set("ArticleNumber", "Article Number");

            Random zufall = new Random();
            DateTime dt = DateTime.Now;
            string invoiceNumber = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString() + Convert.ToString(zufall.Next(-100, 100)).PadLeft(2, '0');
            pd.Set("InvoiceNumber", invoiceNumber);
            pd.Set("ItemDescription", "Payment Detail Description");
            pd.Set("ItemName", "Name of Item");
            pd.Set("Quantity", "1");
            pd.Set("Total", "10.00");
            pd.Set("Execute", "command to execute after payment");

            PaymentPrepare pp = new PaymentPrepare();
            pp.PaymentDetails = pd;
            pp.Description = "Payment description";
            string baseUrl = Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/"));
            pp.UrlCancel = baseUrl + "/PaymentCancel.aspx";
            pp.UrlReturn = baseUrl + "/PaymentComplete.aspx";

            var payment = pp.CreatePayment();
            string paymentId = payment.id;
            pd.Set(pd.PaymentId, paymentId);
            Session[paymentId] = pd;
            Response.Redirect(payment.GetApprovalUrl());
        }
    }
}