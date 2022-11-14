using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deliveraholic_backend.Models
{
    public enum PickupDeliveryDetailsType
    {
        pickup = 0,
        delivery = 1
    }

    public class PickupDeliveryDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pickupDeliveryDetailsID { get; set; }

        public PickupDeliveryDetailsType type { get; set; }

        [MaxLength(100)]
        [Required]
        public string streetname { get; set; }

        [Required]
        public string housenumber { get; set; }

        [Required]
        public string zipcode { get; set; }

        [MaxLength(50)]
        [Required]
        public string residence { get; set; }

        public string comment { get; set; }

        public virtual ICollection<Order> orders { get; set; }
    }
}