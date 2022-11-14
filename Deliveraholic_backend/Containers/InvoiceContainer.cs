using deliveraholic_backend.Interfaces;

namespace deliveraholic_backend.Containers
{
    public class InvoiceContainer
    {
        // Invoice methods based on the DAL.

        readonly IInvoice invoiceDAL;


        public InvoiceContainer(IInvoice invoiceDAL)
        {
            this.invoiceDAL = invoiceDAL;
        }
    }
}