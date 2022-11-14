using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace deliveraholic_backend.Models
{
    public enum StatusType
    {
        pending = 0,
        accepted = 1,
        outForDelivery = 2,
        delivered = 3,
    }

    public enum PackageType
    {
        privatePlace = 0,
        store = 1
    }

    public enum TransportType
    {
        doorToDoor = 0,
        custom = 1
    }

    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderDetailsID { get; set; }

        public StatusType status { get; set; }

        public PackageType package { get; set; }

        public TransportType transport { get; set; }

        public DateTime pickup { get; set; }

        public DateTime delivery { get; set; }

        public string comment { get; set; }

        public DateTime orderedAt { get; set; }
    }
}