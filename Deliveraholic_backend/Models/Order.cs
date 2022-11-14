using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace deliveraholic_backend.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid orderID { get; set; }

        [NotNull]
        public Guid accountID { get; set; }
        [ForeignKey("accountID")]
        public virtual Account account { get; set; }

        [AllowNull]
        public Guid? delivererID { get; set; }

        [NotNull]
        public virtual PickupDeliveryDetails pickupDetails { get; set; }

        [NotNull]
        [InverseProperty("orders")]
        public virtual PickupDeliveryDetails deliveryDetails { get; set; }

        public int paymentID { get; set; }
        [ForeignKey("paymentID")]
        public virtual Payment payment { get; set; }

        public int orderDetailsID { get; set; }
        [ForeignKey("orderDetailsID")]
        public virtual OrderDetails orderDetails { get; set; }
    }
}