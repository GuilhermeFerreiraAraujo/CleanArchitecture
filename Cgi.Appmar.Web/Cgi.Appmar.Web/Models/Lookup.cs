using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class Lookup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<LookupValue> LookupValues { get; } = new List<LookupValue>();
}
