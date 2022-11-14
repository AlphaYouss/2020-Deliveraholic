using System.ComponentModel.DataAnnotations.Schema;

namespace deliveraholic_backend.Models
{
    public class PackageDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int packageDetailsID { get; set; }

        public int orderDetailsID { get; set; }
        [ForeignKey("orderDetailsID")]
        public virtual OrderDetails orderDetails { get; set; }

        public bool pickupHelp { get; set; }

        public int pickupFloor { get; set; }

        public bool deliveryHelp { get; set; }

        public int deliveryFloor { get; set; }
    }
}