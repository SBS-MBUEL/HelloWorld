using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace HelloWorld
{
    public class AuthHandler
    {
        private readonly string grantType = "refresh_token";
        private readonly string refreshToken = "97dba257d2d74896b642ddcf6f44db6c";
        private readonly string tokenUri = "https://auth-sandbox.test.vismaonline.com/eaccountingapi/oauth/token";
        private readonly string redirectUri = "https://localhost:44300/callback";

        public string ProvideToken()
        {
            var authdata = new TokenRequestBodyDto()
            {
                grant_type = grantType,
                refresh_token = refreshToken,
                redirect_uri = redirectUri
            };

            var jss = new JavaScriptSerializer();
            string authJson = jss.Serialize(authdata);
            byte[] authBytes = Encoding.UTF8.GetBytes(authJson);

            using (var client = new WebClient())
            {
                //Base64 encoded clientId + clientSecret
                client.Headers[HttpRequestHeader.Authorization] =
                    $"Basic dmlzbWFzdXBwb3J0OmtPNjJLSzFRajh1b0FQSkxYSnB0c3dYWGZPT05Ia1VpVWFwa1o2NUM4TFE=";
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var response = client.UploadData(tokenUri, authBytes);

                var token = jss.Deserialize<TokenDto>(Encoding.UTF8.GetString(response));
                return token.access_token;
            }
        }
    }
}
