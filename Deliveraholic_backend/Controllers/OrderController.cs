using deliveraholic_backend.Containers;
using deliveraholic_backend.DALs;
using deliveraholic_backend.Models;
using deliveraholic_backend.Tools;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace deliveraholic_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        private OrderContainer oc { get; set; }
        private ApiHandler ah { get; set; }

        private static Account currentAccount { get; set; }

        private static Order order { get; set; }
        private static OrderDetails orderDetails { get; set; }
        private static PickupDeliveryDetails pickupDetails { get; set; }
        private static PickupDeliveryDetails deliveryDetails { get; set; }
        private static PackageDetails packageDetails { get; set; }
        private static List<Item> items { get; set; }
        private static Payment payment { get; set; }

        private Dictionary<string, string> properties { get; set; }
        private decimal routeDistance { get; set; }

        private string errorMessage { get; set; }


        public OrderController(DatabaseContext context)
        {
            // Set container & handler.

            ah = new ApiHandler();
            oc = new OrderContainer(new OrderDAL(context));
        }


        //// [USER] ////


        [Route("user/{userID}")]
        [HttpGet]
        public IActionResult GetSetUser([FromQuery] string userID)
        {
            // Get and set user:

            // Get user details.

            if (GetUser(userID) == string.Empty)
            {
                // Set user details.

                SetUser();

                return Ok("User set!");
            }
            return Conflict(errorMessage);
        }


        private string GetUser(string userID)
        {
            // Create api call:

            properties = ah.CreateACall("https://localhost:5001/api/account/byid/", userID, "userID", false, null);

            if (properties != null)
            {
                // Status is OK(200).

                return string.Empty;
            }
            errorMessage = "Not able to set the user.";
            return errorMessage;
        }


        private void SetUser()
        {
            // Set details in currentAccount:

            Guid userGuid = new Guid(properties["accountID"]);

            currentAccount = new Account
            {
                accountID = userGuid,
                firstName = properties["firstName"],
                lastName = properties["lastName"],
                email = properties["email"],
                phoneNumber = properties["phoneNumber"],
                passwordHash = properties["passwordHash"],
                passwordSalt = properties["passwordSalt"],
                createdAt = Convert.ToDateTime(properties["createdAt"]),
            };

            if (properties["type"] == "0")
            {
                currentAccount.type = AccountType.user;
            }
            else
            {
                currentAccount.type = AccountType.deliverer;
            }
            properties = null;
        }


        //// [CREATE] ////


        [Route("createdetails/order")]
        [HttpPost]
        public IActionResult CreateOrderDetails([FromForm] string packageTypeValue, [FromForm] string transportTypeValue, [FromForm] string dtPickup, [FromForm] string dtDelivery, [FromForm] string comment)
        {
            // Create orderdetails:

            if (CheckOrderDetails(packageTypeValue, transportTypeValue, dtPickup, dtDelivery) == string.Empty)
            {
                // Set orderDetails.

                orderDetails = new OrderDetails
                {
                    status = StatusType.pending,
                    package = (PackageType)Enum.Parse(typeof(PackageType), packageTypeValue),
                    transport = (TransportType)Enum.Parse(typeof(TransportType), transportTypeValue),
                    pickup = Convert.ToDateTime(dtPickup),
                    delivery = Convert.ToDateTime(dtDelivery),
                    comment = comment
                };
                return Ok("Created a new order details!");
            }
            return Conflict(errorMessage);
        }


        private string CheckOrderDetails(string packageTypeValue, string transportTypeValue, string dtPickup, string dtDelivery)
        {
            // Validate properties of orderDetails:

            if (packageTypeValue == null)
            {
                // Package type value is NULL.

                errorMessage = "Please select a valid package type.";
                return errorMessage;
            }
            else if (transportTypeValue == null)
            {
                // Transport type value is NULL.

                errorMessage = "Please select a valid transport type.";
                return errorMessage;
            }
            else if ((PackageType)Enum.Parse(typeof(PackageType), packageTypeValue) != PackageType.privatePlace && (PackageType)Enum.Parse(typeof(PackageType), packageTypeValue) != PackageType.store)
            {
                // Package type doesn't exist.

                errorMessage = "The package type doesn't exist!";
                return errorMessage;
            }
            else if ((TransportType)Enum.Parse(typeof(TransportType), transportTypeValue) != TransportType.custom && (TransportType)Enum.Parse(typeof(TransportType), transportTypeValue) != TransportType.doorToDoor)
            {
                // Transport type doesn't exist.

                errorMessage = "The transport type doesn't exist!";
                return errorMessage;
            }
            else if (Convert.ToDateTime(dtPickup) == new DateTime() || Convert.ToDateTime(dtPickup) == null)
            {
                // Pickup datetime cast failed.

                errorMessage = "Please select a valid pickup date.";
                return errorMessage;
            }
            else if (Convert.ToDateTime(dtDelivery) == new DateTime() || Convert.ToDateTime(dtDelivery) == null)
            {
                // Delivery datetime cast failed.

                errorMessage = "Please select a valid delivery date.";
                return errorMessage;
            }
            return string.Empty;
        }


        [Route("createdetails/pickup")]
        [HttpPost]
        public IActionResult CreatePickupDetails([FromBody] PickupDeliveryDetails givenPickupDetails)
        {
            // Create pickupDetails:

            if (CheckAddress(givenPickupDetails.zipcode, givenPickupDetails.housenumber) == string.Empty)
            {
                // Set pickupDetails.

                pickupDetails = new PickupDeliveryDetails
                {
                    type = PickupDeliveryDetailsType.delivery,
                    streetname = properties["street"],
                    housenumber = properties["number"],
                    zipcode = properties["postcode"],
                    residence = properties["municipality"],
                    comment = pickupDetails.comment
                };
                properties = null;
                return Ok("Created a new pickup details!");
            }
            return Conflict(errorMessage);
        }


        [Route("createdetails/delivery")]
        [HttpPost]
        public IActionResult CreateDeliveryDetails([FromBody] PickupDeliveryDetails givenDeliveryDetails)
        {
            // Create deliverydetails:

            if (CheckAddress(givenDeliveryDetails.zipcode, givenDeliveryDetails.housenumber) == string.Empty)
            {
                // Set deliveryDetails.

                deliveryDetails = new PickupDeliveryDetails
                {
                    type = PickupDeliveryDetailsType.delivery,
                    streetname = properties["street"],
                    housenumber = properties["number"],
                    zipcode = properties["postcode"],
                    residence = properties["municipality"],
                    comment = deliveryDetails.comment
                };
                properties = null;
                return Ok("Created a new order details!");
            }
            return Conflict(errorMessage);
        }


        private string CheckAddress(string zipcode, string housenumber)
        {
            // Create api call:

            properties = ah.CreateACall("https://sandbox.postcodeapi.nu/v3/lookup/" + zipcode + '/' + housenumber, null, null, true, "bdL5NMFHINa0TTZR4DnFcaWetmCY21Kv69Chwqmp");

            if (properties != null)
            {
                // Status is OK(200).

                return string.Empty;
            }
            errorMessage = "Postcode API errorcode: " + ah.GetResponse().StatusCode + "!";
            return errorMessage;
        }


        [Route("createdetails/package")]
        [HttpPost]
        public IActionResult CreatePackageDetails([FromBody] PackageDetails givenPackageDetails)
        {
            // Create packagedetails:

            packageDetails = new PackageDetails
            {
                pickupHelp = givenPackageDetails.pickupHelp,
                pickupFloor = givenPackageDetails.pickupFloor,
                deliveryHelp = givenPackageDetails.deliveryHelp,
                deliveryFloor = givenPackageDetails.deliveryFloor
            };
            return Ok("Created a new package details!");
        }


        [Route("createdetails/items")]
        [HttpPost]
        public IActionResult SetItems([FromBody] List<Item> givenItems)
        {
            // Set items:

            items = new List<Item>();

            foreach (Item item in givenItems)
            {
                // Add item to list.

                items.Add(item);
            }
            return Ok("Items set!");
        }


        [Route("calculateprice")]
        [HttpGet]
        public IActionResult CalculateDistanceAndPrice()
        {
            // Get route distance:

            GetDistance(pickupDetails, deliveryDetails);

            if (properties != null)
            {
                // Status is OK(200).

                if (SetDistance() == string.Empty & SetPayment() == string.Empty)
                {
                    return Ok("Distance and payment set!");
                }
                return Conflict(errorMessage);
            }
            errorMessage = "Unable to get the distance.";
            return Conflict(errorMessage);
        }


        private void GetDistance(PickupDeliveryDetails pickupDetails, PickupDeliveryDetails deliveryDetails)
        {
            // Get route distance:

            // Create api call.

            string url = "https://www.mapquestapi.com/directions/v2/route?key=d5owRABG8flBtz0AgTOy8y0NseAdLRDP&from=" +
            pickupDetails.streetname +
            "%2C+" + pickupDetails.residence +
            "%2C+NLD&to=" + deliveryDetails.streetname +
            "%2C" + deliveryDetails.residence +
            "%2C+NLD&outFormat=json&ambiguities=ignore&routeType=fastest&doReverseGeocode=false&enhancedNarrative=false&avoidTimedConditions=false";

            url = url.Trim();
            properties = ah.CreateACall(url, null, null, false, null);
        }


        private string SetDistance()
        {
            // Set route distance:

            JObject jsonContent = JObject.Parse(properties["route"]);

            // Loop through the account properties.

            foreach (KeyValuePair<string, JToken> jsonProps in jsonContent)
            {
                string key = jsonProps.Key;
                string value = jsonProps.Value.ToString();

                properties[key] = value;
            }

            if (properties == null)
            {
                // Unable to get the distance.

                errorMessage = "Can not find the distance!";
                return errorMessage;
            }

            CalculateDistance();

            properties = null;
            return string.Empty;
        }


        private void CalculateDistance()
        {
            // CalculateDistance (miles to kilometers):

            routeDistance = Convert.ToDecimal(properties["distance"]);

            decimal toKm = (decimal)1.609344;
            routeDistance *= toKm;

            routeDistance = Math.Round(routeDistance, 2);
        }


        private string SetPayment()
        {
            // Set payment:

            payment = new Payment
            {
                type = PaymentType.paypal,
                amount = CalculatePrice()
            };
            return string.Empty;
        }


        private decimal CalculatePrice()
        {
            // Calculate price: 

            decimal mileageCosts = (decimal)1.79;
            decimal price = routeDistance * mileageCosts;

            price += 10;

            foreach (Item item in items)
            {
                decimal itemCosts = 0;

                if (item.length > 40)
                {
                    itemCosts += item.length / 10 * (decimal)0.67;
                }

                if (item.height > 40)
                {
                    itemCosts += item.height / 10 * (decimal)0.532;
                }

                if (item.width > 40)
                {
                    itemCosts += +item.width / 10 * (decimal)0.457;
                }
                itemCosts += (decimal)2.53;
                price += itemCosts;
            }
            return Math.Round(price, 2);
        }


        [Route("pay")]
        [HttpGet]
        public IActionResult PayOrder()
        {
            // Pay order:

            //List<string> paypalConfig = config.GetSection("PaypalDetails").Get<List<string>>();

            //Dictionary<string, string> ppPaymentDetails = new Dictionary<string, string>();

            //ppPaymentDetails.Add("Total", payment.amount.ToString());

            //PaypalPrepare ppPrepare = new PaypalPrepare
            //{
            //    paymentDetails = ppPaymentDetails,
            //    description = "Deliveraholic order.",
            //    urlCancel = "https://www.youtube.com/",
            //    urlReturn = "https://stackoverflow.com/"
            //};

            //PayPal.Api.Payment ppPayment = ppPrepare.CreatePayment(paypalConfig[0], paypalConfig[1]);
            //return Ok(ppPayment.GetApprovalUrl().ToString());

            return Ok();
        }


        [Route("create")]
        [HttpPost]
        public IActionResult CreateOrder()
        {
            // Finish order:

            if (CompleteOrder() == string.Empty)
            {
                return Ok("Order placed!");
            }
            return Conflict(errorMessage);
        }


        private string CompleteOrder()
        {
            // Add order components to DB:

            if (AddPaymentLine() != string.Empty &&
                AddOrderDetails() != string.Empty &&
                AddPackageDetails() != string.Empty &&
                AddOrderItems() != string.Empty &&
                AddPickupAndDeliveryLine() != string.Empty &&
                AddOrder() != string.Empty)
            {
                // Error in one of the methods.

                return errorMessage;
            }
            return string.Empty;
        }


        private string AddPaymentLine()
        {
            // Add payment line to DB:

            if (!oc.NewPayment(payment))
            {
                // Payment error.

                errorMessage = "Unable to create a new payment line!";
                return errorMessage;
            }
            return string.Empty;
        }


        private string AddOrderDetails()
        {
            // Add order details to DB:

            if (!oc.NewOrderDetails(orderDetails))
            {
                // OrderDetails error.

                errorMessage = "Unable to create a new order details!";
                return errorMessage;
            }
            return string.Empty;
        }


        private string AddPackageDetails()
        {
            // Add package details to DB:

            if (packageDetails != null)
            {
                // PackageDetails exists.

                packageDetails.orderDetailsID = orderDetails.orderDetailsID;

                if (!oc.NewPackageDetails(packageDetails))
                {
                    // PackageDetails error.

                    errorMessage = "Unable to create a new package details!";
                    return errorMessage;
                }
                return string.Empty;
            }
            return string.Empty;
        }


        private string AddOrderItems()
        {
            // Add order items to DB:

            foreach (Item item in items)
            {
                item.orderDetailsID = orderDetails.orderDetailsID;
            }

            if (!oc.SetNewOrderItems(items))
            {
                // Order items error.

                errorMessage = "Unable to add the order items!";
                return errorMessage;
            }
            return string.Empty;
        }


        private string AddPickupAndDeliveryLine()
        {
            // Add pickup & delivery line to DB:

            if (!oc.NewPickupDetails(pickupDetails))
            {
                // PickupDetails error.

                errorMessage = "Unable to create a new pickup details!";
                return errorMessage;
            }
            else if (!oc.NewDeliveryDetails(deliveryDetails))
            {
                // DeliveryDetails error.

                errorMessage = "Unable to create a new delivery details!";
                return errorMessage;
            }
            return string.Empty;
        }


        private string AddOrder()
        {
            // Add order to DB:

            order = new Order
            {
                paymentID = payment.paymentID,
                orderDetailsID = orderDetails.orderDetailsID,
                accountID = currentAccount.accountID,
                pickupDetails = pickupDetails,
                deliveryDetails = deliveryDetails,
                delivererID = null
            };

            if (!oc.NewOrder(order))
            {
                // New order error.

                errorMessage = "Unable to create a new order!";
                return errorMessage;
            }
            return string.Empty;
        }
    }
}