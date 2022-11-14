using deliveraholic_backend.Interfaces;

namespace deliveraholic_backend.DALs
{
    public class UserDAL : IUser
    {
        private DatabaseContext dc { get; set; }


        public UserDAL(DatabaseContext context)
        {
            // Set database context.

            dc = context;
        }
    }
}