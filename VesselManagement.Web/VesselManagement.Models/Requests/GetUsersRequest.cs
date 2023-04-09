namespace Cgi.Appmar.Models.Requests
{
    public class GetUsersRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
