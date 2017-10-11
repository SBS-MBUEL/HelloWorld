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
        private readonly string supplierInvoiceUri = "https://eaccountingapi-sandbox.test.vismaonline.com/v2/supplierinvoices";

        public SupplierInvoicesApiDto GetSupplierInvoices(string accessToken)
        {
            var jss = new JavaScriptSerializer();

            using (var client = new WebClient())
            {
                //Define content type
                client.Headers[HttpRequestHeader.ContentType] = 
                    "application/json";
                client.Headers[HttpRequestHeader.Authorization] =
                    $"Bearer {accessToken}";

                //Call api and save response
                var response = client.DownloadString(supplierInvoiceUri);
                
                //Convert response to Datamodel
                var deserializedResponse = jss.Deserialize<SupplierInvoicesApiDto>(response);

                return deserializedResponse;
            }
        }
    }
}
