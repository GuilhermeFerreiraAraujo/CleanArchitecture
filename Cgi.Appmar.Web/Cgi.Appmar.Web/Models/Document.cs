using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class Document
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int VesselId { get; set; }

    public string? DocPath { get; set; }

    public int? DocumentTypeId { get; set; }

    public bool IsDraft { get; set; }

    public bool IsValid { get; set; }

    public bool IsNecessary { get; set; }

    public string? UniqueTrackNumber { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual DocumentType? DocumentType { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }

    public virtual Vessel Vessel { get; set; } = null!;
}
