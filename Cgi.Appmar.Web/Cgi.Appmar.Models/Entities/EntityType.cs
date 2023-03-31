using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class EntityType : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public virtual ICollection<Approval> Approvals { get; } = new List<Approval>();

    public virtual ICollection<LookupEntityValue> LookupEntityValues { get; } = new List<LookupEntityValue>();
}
