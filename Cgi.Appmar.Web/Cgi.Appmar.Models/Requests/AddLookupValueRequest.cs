namespace Cgi.Appmar.Models.Requests
{
    public class AddLookupValueRequest
    {
        public int LookupId { get; set; }
        public string LookupValue { get; set; } = string.Empty;
    }
}
