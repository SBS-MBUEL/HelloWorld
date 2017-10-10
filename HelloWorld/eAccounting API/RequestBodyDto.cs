namespace HelloWorld
{
    public class RequestBodyDto
    {
        public string refresh_token { get; set; }
        public string grant_type { get; set; }
        public string redirect_uri { get; set; }
    }
}