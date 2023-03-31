using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Category : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();
}
