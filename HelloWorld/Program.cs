using HelloWorld.eAccounting_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var authHandler = new AuthHandler();
            var token = authHandler.ProvideToken();

            Console.WriteLine(token);
            Console.ReadLine();
            var invoiceHandler = new InvoiceHandler();
            var invoices = invoiceHandler.GetSupplierInvoices(token);

            Console.WriteLine(invoices.Meta.ServerTimeUtc);
            Console.Read();
        }
    }
}
