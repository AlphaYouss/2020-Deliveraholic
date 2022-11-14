using System;
using System.Web.UI.WebControls;

namespace PayPal_Demo.paypal
{
    public partial class PaymentComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paymentId = string.Empty;
            if (!String.IsNullOrEmpty(Request.QueryString["paymentId"]))
                paymentId = Request.QueryString["paymentId"];

            string token = "-";
            if (!String.IsNullOrEmpty(Request.QueryString["token"]))
                token = Request.QueryString["token"];

            string PayerId = "-";
            if (!String.IsNullOrEmpty(Request.QueryString["PayerID"]))
                PayerId = Request.QueryString["PayerID"];

            Label label = new Label();
            label.Text = "paymentId: " + paymentId + "<br />";
            divPaymentDetails.Controls.Add(label);

            label = new Label();
            label.Text = "PayerId: " + PayerId + "<br />";
            divPaymentDetails.Controls.Add(label);

            label = new Label();
            label.Text = "InvoiceNumber: " + GetPaymentDetails(paymentId, "InvoiceNumber") + "<br />";
            divPaymentDetails.Controls.Add(label);

            label = new Label();
            label.Text = "ItemName: " + GetPaymentDetails(paymentId, "ItemName") + "<br />";
            divPaymentDetails.Controls.Add(label);
        }


        string GetPaymentDetails(string paymentId, string key)
        {
            PaymentDetails pd = (PaymentDetails)Session[paymentId];

            string value = pd.GetString(key);
            if (String.IsNullOrEmpty(value))
                return string.Empty;
            else
                return value;
        }
    }
}