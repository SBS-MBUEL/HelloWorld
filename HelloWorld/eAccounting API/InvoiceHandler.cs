using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HelloWorld.eAccounting_API
{
    public class InvoiceHandler
    {
        private string supplierInvoiceUri = "https://eaccountingapi-sandbox.test.vismaonline.com/v2/supplierinvoices";

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
                    supplierInvoiceUri = $"https://eaccountingapi-sandbox.test.vismaonline.com/v2/supplierinvoices?$page={currentPage}";

                    var pageResponse = client.DownloadString(supplierInvoiceUri);
                    var deserializedPageResponse = jss.Deserialize<SupplierInvoicesApiDto>(pageResponse);
                    supplierInvoices.AddRange(deserializedPageResponse.Data);

                }

                return supplierInvoices;
            }
        }
    }
}
