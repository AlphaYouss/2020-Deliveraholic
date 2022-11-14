using deliveraholic_backend.Interfaces;

namespace deliveraholic_backend.Containers
{
    public class UserContainer
    {
        // User methods based on the DAL

        readonly IUser userDAL;


        public UserContainer(IUser userDAL)
        {
            this.userDAL = userDAL;
        }
    }
}