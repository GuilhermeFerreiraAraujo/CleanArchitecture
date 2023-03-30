using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class FeeChargedStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public virtual ICollection<Feechaged> Feechageds { get; } = new List<Feechaged>();
}
