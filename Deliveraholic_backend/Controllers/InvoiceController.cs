using deliveraholic_backend.Containers;
using deliveraholic_backend.DALs;
using Microsoft.AspNetCore.Mvc;

namespace deliveraholic_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private InvoiceContainer ic { get; set; }


        public InvoiceController(DatabaseContext context)
        {
            // Set container.

            ic = new InvoiceContainer(new InvoiceDAL(context));
        }
    }
}