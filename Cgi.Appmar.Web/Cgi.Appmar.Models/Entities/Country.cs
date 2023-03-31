using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Country : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();
}
