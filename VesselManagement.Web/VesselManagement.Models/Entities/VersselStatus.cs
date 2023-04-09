using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class VersselStatus : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public virtual ICollection<Vessel> Vessels { get; } = new List<Vessel>();
}
