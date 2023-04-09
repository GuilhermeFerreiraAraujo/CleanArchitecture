using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class RolesPermission : IBaseEntity
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
