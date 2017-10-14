using HelloWorld.eAccounting_API;
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start.");
            Console.ReadLine();
            var authHandler = new AuthHandler();
            var token = authHandler.ProvideToken();

            Console.WriteLine("Access token aquired.");
            var invoiceHandler = new InvoiceHandler();
            var invoices = invoiceHandler.GetSupplierInvoices(token);

            var machineLearningHandler = new MachineLearningInvoiceHandler();
            Console.WriteLine("Looping invoices...");
            foreach (var invoice in invoices)
            {
                
                Console.WriteLine(machineLearningHandler.ValidateInvoice(invoice));
            }

            Console.Read();
        }
    }
}
