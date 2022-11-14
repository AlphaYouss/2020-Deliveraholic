using deliveraholic_backend.Interfaces;
using deliveraholic_backend.Models;
using System.Collections.Generic;

namespace deliveraholic_backend.Containers
{
    public class OrderContainer
    {
        // Order methods based on the DAL.

        readonly IOrder orderDAL;


        public OrderContainer(IOrder orderDAL)
        {
            this.orderDAL = orderDAL;
        }


        public bool NewPackageDetails(PackageDetails packageDetails)
        {
            return orderDAL.NewPackageDetails(packageDetails);
        }


        public bool NewOrderDetails(OrderDetails orderDetails)
        {
            return orderDAL.NewOrderDetails(orderDetails);
        }


        public bool SetNewOrderItems(List<Item> items)
        {
            return orderDAL.SetNewOrderItems(items);
        }


        public bool NewPayment(Payment payment)
        {
            return orderDAL.NewPayment(payment);
        }


        public bool NewPickupDetails(PickupDeliveryDetails pickupDetails)
        {
            return orderDAL.NewPickupDetails(pickupDetails);
        }


        public bool NewDeliveryDetails(PickupDeliveryDetails deliveryDetails)
        {
            return orderDAL.NewDeliveryDetails(deliveryDetails);
        }


        public bool NewOrder(Order order)
        {
            return orderDAL.NewOrder(order);
        }
    }
}