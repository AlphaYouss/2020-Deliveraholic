using deliveraholic_backend.Containers;
using deliveraholic_backend.DALs;
using Microsoft.AspNetCore.Mvc;

namespace deliveraholic_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserContainer uc { get; set; }


        public UserController(DatabaseContext context)
        {
            // Set container.

            uc = new UserContainer(new UserDAL(context));
        }
    }
}