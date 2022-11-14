using deliveraholic_backend.Interfaces;

namespace deliveraholic_backend.DALs
{
    public class DelivererDAL : IDeliverer
    {
        private DatabaseContext dc { get; set; }


        public DelivererDAL(DatabaseContext context)
        {
            // Set database context.

            dc = context;
        }
    }
}