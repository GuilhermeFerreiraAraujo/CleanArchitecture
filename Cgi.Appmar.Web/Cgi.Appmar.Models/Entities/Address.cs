using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Address : IBaseEntity
{
    public int Id { get; set; }

    public int EntityId { get; set; }

    public int EntityTypeId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public int CountryId { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public bool IsMainAddress { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? UpdateByNavigation { get; set; }
}
