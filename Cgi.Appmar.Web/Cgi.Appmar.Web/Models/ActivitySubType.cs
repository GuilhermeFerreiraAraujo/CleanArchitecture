using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class ActivitySubType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Activity> Activities { get; } = new List<Activity>();
}
