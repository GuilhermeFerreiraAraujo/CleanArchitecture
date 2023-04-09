namespace Cgi.Appmar.Models.Requests
{
    public class UpdateRoleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Dsc { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<int> PermissionIds { get; set; } = new List<int>();
    }
}
