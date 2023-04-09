using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Models.Entities;
using System.Data;

namespace Cgi.Appmar.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly AppmarContext context;

        public RoleRepository(AppmarContext _context) : base(_context)
        {
            this.context = _context;
        }

        public List<RolesPermission> GetRolePermissions(int roleId)
        {
            return context.RolesPermissions.Where(x => x.RoleId == roleId).ToList();
        }

        public void RemovePermissionByRoleId(int roleId)
        {
            var rolePermissions = context.RolesPermissions.Where(x => x.RoleId == roleId);

            context.RolesPermissions.RemoveRange(rolePermissions);
            context.SaveChanges();
        }

        public void UpdateRolePermissions(int roleId, List<int> permissionIds)
        {
            var permissions = context.RolesPermissions.Where(x => x.RoleId == roleId).ToList();
            context.RemoveRange(permissions);

            var newPermissions = new List<RolesPermission>();

            foreach (var permission in permissionIds)
            {
                newPermissions.Add(new RolesPermission
                {
                    RoleId = roleId,
                    PermissionId = permission
                });
            }

            context.RolesPermissions.AddRange(newPermissions);
            context.SaveChanges();
        }

        public void Update(Role role, List<int> permissionIds)
        {
            var permissions = context.RolesPermissions.Where(x => x.RoleId == role.Id).ToList();
            context.RemoveRange(permissions);

            var newPermissions = new List<RolesPermission>();

            foreach (var permission in permissionIds)
            {
                newPermissions.Add(new RolesPermission
                {
                    RoleId = role.Id,
                    PermissionId = permission
                });
            }

            context.Roles.Update(role);
            context.RolesPermissions.AddRange(newPermissions);
            context.SaveChanges();
        }
    }
}
