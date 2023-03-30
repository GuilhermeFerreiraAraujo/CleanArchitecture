using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class Organization
{
    public int Id { get; set; }

    public int OrganizationTypeId { get; set; }

    public string? Imo { get; set; }

    public string? FiscalNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Dsc { get; set; } = null!;

    public int CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual OrganizationType OrganizationType { get; set; } = null!;

    public virtual User? UpdateByNavigation { get; set; }
}
