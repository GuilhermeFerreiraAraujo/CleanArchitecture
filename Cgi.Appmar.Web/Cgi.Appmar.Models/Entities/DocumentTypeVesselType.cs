using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class DocumentTypeVesselType
{
    public int? Id { get; set; }

    public int DocumentTypeId { get; set; }

    public int VesselTypeId { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual VersselType VesselType { get; set; } = null!;
}
