using deliveraholic_backend.Models;
using System.Collections.Generic;

namespace deliveraholic_backend.Interfaces
{
    public interface IOrder
    {
        // Order methods:

        bool NewPackageDetails(PackageDetails packageDetails);
        bool NewOrderDetails(OrderDetails orderDetails);
        bool SetNewOrderItems(List<Item> items);
        bool NewPayment(Payment payment);
        bool NewPickupDetails(PickupDeliveryDetails pickupDetails);
        bool NewDeliveryDetails(PickupDeliveryDetails deliveryDetails);
        bool NewOrder(Order order);
    }
}