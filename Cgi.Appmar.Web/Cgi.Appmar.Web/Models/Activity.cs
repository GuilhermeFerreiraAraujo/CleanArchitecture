using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class Activity
{
    public int Id { get; set; }

    public int VesselId { get; set; }

    public int RequestId { get; set; }

    public int ActivityTypeId { get; set; }

    public int ActivitySubtypeId { get; set; }

    public int ActivityStatusId { get; set; }

    public string? CsrDocNum { get; set; }

    public string? RejectDesc { get; set; }

    public int? RequestedOrgId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UbdatedDate { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ActivitySubType ActivitySubtype { get; set; } = null!;

    public virtual ActivityType ActivityType { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? UpdateByNavigation { get; set; }

    public virtual Vessel Vessel { get; set; } = null!;
}
