using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class LookupEntityValue : IBaseEntity
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public int EntityTypeId { get; set; }

    public int? EntityId { get; set; }

    public virtual EntityType EntityType { get; set; } = null!;
}
