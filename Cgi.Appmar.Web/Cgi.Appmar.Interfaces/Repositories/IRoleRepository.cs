using Cgi.Appmar.Models.Entities;

namespace Cgi.Appmar.Interfaces.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        List<RolesPermission> GetRolePermissions(int roleId);
        void Update(Role role, List<int> permissionIds);
        void RemovePermissionByRoleId(int roleId);
        void UpdateRolePermissions(int roleId, List<int> permissionIds);
    }
}