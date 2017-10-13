using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HelloWorld.eAccounting_API
{
    public class MachineLearningInvoiceHandler
    {
        private readonly string requestUri = "https://ussouthcentral.services.azureml.net/workspaces/725897a5fb384db59e22b1aac7e70c1e/services/bbd6cb1932be41c789237764368931b0/execute?api-version=2.0&details=true";
        private readonly string apiKey = "Shl43nUR9u8TWvXpj+lxwKhQ4f7dOOnUz5Kw4kfsDm3dTBygekbAcYJmGVigURKHuf5rACTPkq0y5WAUJxbzsA==";

        public string ValidateInvoice(SupplierInvoiceApi invoice)
        {
            var jss = new JavaScriptSerializer();

            using (var client = new WebClient())
            {

                //Encode...
                client.Encoding = Encoding.UTF8;

                //Define content type
                client.Headers[HttpRequestHeader.ContentType] =
                    "application/json";

                //Define auth header
                client.Headers[HttpRequestHeader.Authorization] =
                    $"Bearer {apiKey}";



                MachineLearningDto requestBody = new MachineLearningDto();
                requestBody.Inputs.input1.ColumnNames = new List<string>
                {
                    "supplier_name",
                    "invoice_date",
                    "due_date",
                    "invoice_number",
                    "total_amount",
                    "vat",
                    "currency_code",
                    "ocr_number",
                    "message",
                    "bank_giro",
                    "is_fake"
                };


                var values = new List<string>
                {
                    invoice.SupplierName,
                    invoice.InvoiceDate,
                    invoice.DueDate,
                    invoice.InvoiceNumber,
                    invoice.TotalAmount.ToString(),
                    invoice.Vat.ToString(),
                    invoice.CurrencyCode,
                    invoice.OcrNumber,
                    invoice.Message,
                    invoice.BankGiroNumber,
                    "false"
                };

                requestBody.Inputs.input1.Values = new List<List<string>>();
                requestBody.Inputs.input1.Values.Add(values);

                var serializedRequestBody = jss.Serialize(requestBody);
                string response = "";

                Console.WriteLine(serializedRequestBody);

                try
                {
                    response = client.UploadString(requestUri, serializedRequestBody);
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                }

                return response;
            }
        }
    }
}
