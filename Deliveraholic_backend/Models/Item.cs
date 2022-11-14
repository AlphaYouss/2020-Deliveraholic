using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deliveraholic_backend.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemID { get; set; }

        public int orderDetailsID { get; set; }
        [ForeignKey("orderDetailsID")]
        public virtual OrderDetails orderDetails { get; set; }

        [MaxLength(75)]
        [MinLength(2)]
        [Required]
        public string name { get; set; }

        public decimal height { get; set; }

        public decimal width { get; set; }

        public decimal length { get; set; }

        public string description { get; set; }
    }
}