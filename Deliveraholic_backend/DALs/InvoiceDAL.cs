using deliveraholic_backend.Interfaces;

namespace deliveraholic_backend.DALs
{
    public class InvoiceDAL : IInvoice
    {
        private DatabaseContext dc { get; set; }


        public InvoiceDAL(DatabaseContext context)
        {
            // Set database context.

            dc = context;
        }
    }
}