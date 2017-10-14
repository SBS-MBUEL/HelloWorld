using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace HelloWorld.eAccounting_API
{
    public class InvoiceHandler
    {
        private string supplierInvoiceUri = "https://eaccountingapi-sandbox.test.vismaonline.com/v2/supplierinvoicedrafts";

        /// <summary>
        /// Provide access token in order to perform the API request
        /// </summary>
        /// <param name="accessToken">The authentication token provided by the AuthenticationHandler</param>
        /// <returns></returns>
        public IEnumerable<SupplierInvoiceApi> GetSupplierInvoices(string accessToken)
        {
            var jss = new JavaScriptSerializer();
            int currentPage = 1;
            var supplierInvoices = new List<SupplierInvoiceApi>();

            using (var client = new WebClient())
            {
                
                //Encode...
                client.Encoding = Encoding.UTF8;
                
                //Define content type
                client.Headers[HttpRequestHeader.ContentType] = 
                    "application/json";

                //Define auth header
                client.Headers[HttpRequestHeader.Authorization] =
                    $"Bearer {accessToken}";

                //Call api and save response
                var response = client.DownloadString(supplierInvoiceUri);

                
                //Convert response to Datamodel
                var deserializedResponse = jss.Deserialize<SupplierInvoicesApiDto>(response);
                supplierInvoices.AddRange(deserializedResponse.Data);

                while(deserializedResponse.Meta.TotalNumberOfPages >= currentPage)
                {
                    currentPage++;
                    supplierInvoiceUri = $"https://eaccountingapi-sandbox.test.vismaonline.com/v2/supplierinvoicedrafts?$page={currentPage}";

                    var pageResponse = client.DownloadString(supplierInvoiceUri);
                    var deserializedPageResponse = jss.Deserialize<SupplierInvoicesApiDto>(pageResponse);
                    supplierInvoices.AddRange(deserializedPageResponse.Data);

                }

                return supplierInvoices;
            }
        }

        public SupplierInvoiceApi GetSingleSupplierInvoice(string accessToken)
        {
            var jss = new JavaScriptSerializer();
            var supplierInvoice = new SupplierInvoiceApi();

            using (var client = new WebClient())
            {
                //Encode...
                client.Encoding = Encoding.UTF8;

                //Define content type
                client.Headers[HttpRequestHeader.ContentType] =
                    "application/json";

                //Define auth header
                client.Headers[HttpRequestHeader.Authorization] =
                    $"Bearer {accessToken}";

                //Call api and save response
                // Here are a few Id's of existing invoices that you can pass in the request.
                // a31d5f22-0c1b-40ff-be0b-6228fcb87986
                // 3e598116-58ab-4780-a040-7b23de47c347
                // b6e31c41-279b-4f06-841f-5505b548eddc
                var response = client.DownloadString($"{supplierInvoiceUri}/a31d5f22-0c1b-40ff-be0b-6228fcb87986");


                //Convert response to Datamodel
                supplierInvoice = jss.Deserialize<SupplierInvoiceApi>(response);
            }

            return supplierInvoice;
        }
    }
}
