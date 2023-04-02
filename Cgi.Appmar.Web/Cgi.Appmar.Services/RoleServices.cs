using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Models.Entities;
using Cgi.Appmar.Models.Requests;

namespace Cgi.Appmar.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository roleRepository;

        public RoleServices(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }

        public Role AddRole(AddRoleRequest request)
        {
            var role = new Role
            {
                Name = request.Name,
                Dsc = request.Dsc,
            };

            roleRepository.Add(role);   
            roleRepository.UpdateRolePermissions(role.Id, request.PermissionIds);
            
            return role;
        }

        public Role GetRoleById(int id)
        {
            return roleRepository.GetById(id);
        }

        public void Update(UpdateRoleRequest request)
        {
            var role = roleRepository.GetById(request.Id);

            role.Name = request.Name;
            role.Dsc = request.Dsc;
            role.IsActive = request.IsActive;

            roleRepository.Update(role, request.PermissionIds);
        }

        public void UpdateRolePermissions(UpdateRolePermissionsRequest request)
        {
            roleRepository.UpdateRolePermissions(request.RoleId, request.PermissionIds);
        }
    }
}
