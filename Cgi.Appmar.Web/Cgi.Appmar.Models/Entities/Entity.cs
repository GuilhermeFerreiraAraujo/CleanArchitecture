using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Entity : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public virtual ICollection<Approval> Approvals { get; } = new List<Approval>();
}
