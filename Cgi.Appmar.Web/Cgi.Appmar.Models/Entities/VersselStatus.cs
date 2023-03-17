
using Cgi.Appmar.Models.Entities;

public partial class VersselStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public virtual ICollection<Vessel> Vessels { get; } = new List<Vessel>();
}
