using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Approval : IBaseEntity
{
    public int Id { get; set; }

    public int EntityId { get; set; }

    public int EntityTypeId { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsParentApproval { get; set; }

    public string? Comment { get; set; }

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual Entity Entity { get; set; } = null!;

    public virtual EntityType EntityType { get; set; } = null!;
}
