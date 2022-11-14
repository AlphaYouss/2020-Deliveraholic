using System.ComponentModel.DataAnnotations.Schema;

namespace deliveraholic_backend.Models
{
    public enum PaymentType
    {
        paypal = 0,
        other = 1
    }

    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int paymentID { get; set; }

        public PaymentType type { get; set; }

        public decimal amount { get; set; }
    }
}