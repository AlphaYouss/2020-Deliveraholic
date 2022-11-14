using deliveraholic_backend.Models;
using deliveraholic_backend.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace deliveraholic_backend.DALs
{
    public class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            // Creating data for DB.

            context.Database.EnsureCreated();

            // Look for data.

            if (context.accounts.Any() &&
                context.payments.Any() &&
                context.orderDetails.Any() &&
                context.packageDetails.Any() &&
                context.items.Any() &&
                context.pickupDeliveryDetails.Any() &&
                context.orders.Any())
            {
                // DB has been seeded.

                return;
            }

            // Account:

            PasswordHandler ph = new PasswordHandler();
            string[] passwordData = ph.GenerateSaltAndHash("Welkom12345");

            List<Account> accounts = new List<Account>
            {
                new Account{
                    accountID = new Guid("80E348D3-1F24-EB11-8113-005056A74E91"),
                    firstName ="Carson",
                    lastName="Alexander",
                    email="Carson.Alexander@gmail.com",
                    phoneNumber="+31651553825",
                    type=AccountType.user,
                    passwordHash=passwordData[0],
                    passwordSalt=passwordData[1],
                    createdAt=DateTime.Now,
                },
                new Account{
                    accountID = new Guid("81E348D3-1F24-EB11-8113-005056A74E91"),
                    firstName ="Youssef",
                    lastName="El Jaddaoui",
                    email="youss.eljaddaoui@gmail.com",
                    phoneNumber="+31651553825",
                    type=AccountType.deliverer,
                    passwordHash=passwordData[0],
                    passwordSalt=passwordData[1],
                    createdAt=DateTime.Now,
                },
            };
            accounts.ForEach(a => context.accounts.Add(a));
            context.SaveChanges();

            // Payments:

            List<Payment> payments = new List<Payment>
            {
                new Payment
                {
                    type = PaymentType.paypal,
                    amount = 35
                },
                new Payment
                {
                    type = PaymentType.paypal,
                    amount = 89
                },
            };
            payments.ForEach(p => context.payments.Add(p));
            context.SaveChanges();

            // OrderDetails:

            List<OrderDetails> orderDetails = new List<OrderDetails>
            {
                new OrderDetails
                {
                    status = StatusType.pending,
                    package = PackageType.privatePlace,
                    transport = TransportType.doorToDoor,
                    pickup = DateTime.Now.AddDays(7),
                    delivery = DateTime.Now.AddDays(7),
                    orderedAt = DateTime.Now
                },
                new OrderDetails
                {
                    status = StatusType.pending,
                    package = PackageType.privatePlace,
                    transport = TransportType.custom,
                    pickup = DateTime.Now.AddDays(7),
                    delivery = DateTime.Now.AddDays(7),
                    comment = "Bel kapot.",
                    orderedAt = DateTime.Now
                },
            };
            orderDetails.ForEach(od => context.orderDetails.Add(od));
            context.SaveChanges();

            // PackageDetails:

            List<PackageDetails> packageDetails = new List<PackageDetails>
            {
                new PackageDetails
                {
                    orderDetailsID = orderDetails[1].orderDetailsID,
                    pickupHelp = true,
                    pickupFloor = 2,
                    deliveryHelp = true,
                    deliveryFloor = 8
                },
            };
            packageDetails.ForEach(pd => context.packageDetails.Add(pd));
            context.SaveChanges();

            // Items:

            List<Item> items = new List<Item>
            {
                new Item
                {
                    orderDetailsID = orderDetails[0].orderDetailsID,
                    name = "Magnetron",
                    height = 35,
                    width = 45,
                    length = 39,
                },
                new Item
                {
                    orderDetailsID = orderDetails[1].orderDetailsID,
                    name = "Magnetron",
                    height = 35,
                    width = 45,
                    length = 39,
                },
                new Item
                {
                    orderDetailsID = orderDetails[1].orderDetailsID,
                    name = "Vriezer",
                    height = 95,
                    width = 55,
                    length = 60,
                    description = "Vriezer met glazen deur."
                },
            };
            items.ForEach(i => context.items.Add(i));
            context.SaveChanges();

            // PickupDeliveryDetails:

            List<PickupDeliveryDetails> pickupDeliveryDetails = new List<PickupDeliveryDetails>
            {
                new PickupDeliveryDetails
                {
                    type = PickupDeliveryDetailsType.pickup,
                    streetname = "Poperingestraat",
                    housenumber = "18",
                    zipcode = "4826AL",
                    residence = "Breda",
                    comment = "Bel is kapot."
                },
                new PickupDeliveryDetails
                {
                    type = PickupDeliveryDetailsType.delivery,
                    streetname = "Poperingestraat",
                    housenumber = "8",
                    zipcode = "4826AL",
                    residence = "Breda",
                },
                new PickupDeliveryDetails
                {
                    type = PickupDeliveryDetailsType.pickup,
                    streetname = "moeskroenstraat",
                    housenumber = "18",
                    zipcode = "4826AL",
                    residence = "Breda",
                },
                new PickupDeliveryDetails
                {
                    type = PickupDeliveryDetailsType.delivery,
                    streetname = "moeskroenstraat",
                    housenumber = "8",
                    zipcode = "4826AL",
                    residence = "Breda",
                    comment = "Bel is kapot."
                },
            };
            pickupDeliveryDetails.ForEach(pdD => context.pickupDeliveryDetails.Add(pdD));
            context.SaveChanges();

            // Orders:

            List<Order> orders = new List<Order>
            {
                new Order
                {
                    accountID = accounts[0].accountID,
                    delivererID = null,
                    paymentID = payments[0].paymentID,
                    orderDetailsID = orderDetails[0].orderDetailsID,
                    pickupDetails = pickupDeliveryDetails[0],
                    deliveryDetails = pickupDeliveryDetails[1]
                },
                new Order
                {
                    accountID = accounts[0].accountID,
                    delivererID = null,
                    paymentID = payments[1].paymentID,
                    orderDetailsID = orderDetails[1].orderDetailsID,
                    pickupDetails = pickupDeliveryDetails[2],
                    deliveryDetails = pickupDeliveryDetails[3]
                },
            };
            orders.ForEach(o => context.orders.Add(o));
            context.SaveChanges();
        }
    }
}