using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class LookupValue : IBaseEntity
{
    public int Id { get; set; }

    public int LookupId { get; set; }

    public string? Value { get; set; }

    public virtual Lookup Lookup { get; set; } = null!;
}
