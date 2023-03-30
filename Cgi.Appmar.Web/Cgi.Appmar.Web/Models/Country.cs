using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();
}
