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

            var machineLearningHandler = new MachineLearningInvoiceHandler();
            Console.WriteLine("Looping invoices...");
            foreach (var invoice in invoices)
            {
                
                Console.WriteLine(machineLearningHandler.ValidateInvoice(invoice));
                Console.ReadLine();
            }

            Console.Read();
        }
    }
}
