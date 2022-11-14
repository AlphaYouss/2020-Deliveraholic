using deliveraholic_backend.Interfaces;
using deliveraholic_backend.Models;
using System;
using System.Collections.Generic;

namespace deliveraholic_backend.DALs
{
    public class OrderDAL : IOrder
    {
        private DatabaseContext dc { get; set; }


        public OrderDAL(DatabaseContext context)
        {
            // Set database context.

            dc = context;
        }


        public bool NewOrderDetails(OrderDetails orderDetails)
        {
            orderDetails.orderedAt = DateTime.Now;

            dc.orderDetails.Add(orderDetails);

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool NewPackageDetails(PackageDetails packageDetails)
        {
            dc.packageDetails.Add(packageDetails);

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool NewDeliveryDetails(PickupDeliveryDetails deliveryDetails)
        {
            dc.pickupDeliveryDetails.Add(deliveryDetails);

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool NewOrder(Order order)
        {
            dc.orders.Add(order);

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool NewPayment(Payment payment)
        {
            dc.payments.Add(payment);

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool NewPickupDetails(PickupDeliveryDetails pickupDetails)
        {
            dc.pickupDeliveryDetails.Add(pickupDetails);

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool SetNewOrderItems(List<Item> items)
        {
            foreach (Item item in items)
            {
                dc.items.Add(item);
            }

            if (dc.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}