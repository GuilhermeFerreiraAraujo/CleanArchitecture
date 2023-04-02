namespace Cgi.Appmar.Models.Requests
{
    public class AddRoleRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Dsc { get; set; } = string.Empty;
        public List<int> PermissionIds { get; set; } = new List<int>();
    }
}
