using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Vessel : IBaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Former { get; set; }

    public int? VesselTypeId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public int? VesselStatusId { get; set; }

    public string? PreviousFlag { get; set; }

    public string? FromRegistry { get; set; }

    public string? PretendedAreaOfNavigation { get; set; }

    public string? RegistrationPort { get; set; }

    public string? RegistryNumber { get; set; }

    public int? YearBuilt { get; set; }

    public int? CountryBuilt { get; set; }

    public string? PlaceBuilt { get; set; }

    public string? HullMaterial { get; set; }

    public string? HullIdentificationNumber { get; set; }

    public string? MainEngineBuilder { get; set; }

    public string? NoAndTypeOfEngine { get; set; }

    public string? TotalPowerKw { get; set; }

    public string? MainEnginesStrokeType { get; set; }

    public string? MainEngineFuelType { get; set; }

    public int? NumberOfWinchesFore { get; set; }

    public int? NumberOfWinchesAft { get; set; }

    public int? NumberOfSelfTensionWinchesFore { get; set; }

    public int? NumberOfSelfTensionWinchesAft { get; set; }

    public decimal? DeadWeightTons { get; set; }

    public decimal? GrossTonnage { get; set; }

    public decimal? NegTonnage { get; set; }

    public decimal? LengthOvehal { get; set; }

    public decimal? LengthItc { get; set; }

    public decimal? BreadthItc { get; set; }

    public decimal? DepthItc { get; set; }

    public string? FullLoadDisplacement { get; set; }

    public string? LightShipDisplacement { get; set; }

    public string? Notes { get; set; }

    public string? Remarks { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public virtual ICollection<Activity> Activities { get; } = new List<Activity>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual User? UpdateByNavigation { get; set; }

    public virtual VersselStatus? VesselStatus { get; set; }

    public virtual VersselType? VesselType { get; set; }
}
