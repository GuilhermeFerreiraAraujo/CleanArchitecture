using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Permission : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<RolesPermission> RolesPermissions { get; } = new List<RolesPermission>();
}
