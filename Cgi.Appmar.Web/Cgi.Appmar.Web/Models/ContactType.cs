using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class ContactType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();
}
