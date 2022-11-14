using deliveraholic_backend.Containers;
using deliveraholic_backend.DALs;
using Microsoft.AspNetCore.Mvc;

namespace deliveraholic_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DelivererController : Controller
    {
        private DelivererContainer dc { get; set; }


        public DelivererController(DatabaseContext context)
        {
            // Set container.

            dc = new DelivererContainer(new DelivererDAL(context));
        }
    }
}