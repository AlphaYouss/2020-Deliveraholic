using deliveraholic_backend.Interfaces;

namespace deliveraholic_backend.Containers
{
    public class DelivererContainer
    {
        // Deliverer methods based on the DAL.

        readonly IDeliverer delivererDAL;


        public DelivererContainer(IDeliverer delivererDAL)
        {
            this.delivererDAL = delivererDAL;
        }
    }
}