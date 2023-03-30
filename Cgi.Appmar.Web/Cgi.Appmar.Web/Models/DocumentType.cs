using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dsc { get; set; }

    public virtual ICollection<Document> Documents { get; } = new List<Document>();
}
