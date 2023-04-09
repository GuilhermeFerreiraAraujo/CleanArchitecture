using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Interfaces.Services
{
    public interface IRoleServices
    {
        Role AddRole(AddRoleRequest request);
        Role GetRoleById(int id);
        void Update(UpdateRoleRequest request);
        void UpdateRolePermissions(UpdateRolePermissionsRequest request);
    }
}
