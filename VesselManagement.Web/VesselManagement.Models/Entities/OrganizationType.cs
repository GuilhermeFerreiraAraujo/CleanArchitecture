using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class OrganizationType : IBaseEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Dsc { get; set; }

    public virtual ICollection<Organization> Organizations { get; } = new List<Organization>();
}
