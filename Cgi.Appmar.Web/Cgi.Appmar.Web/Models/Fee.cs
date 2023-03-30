using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class Fee
{
    public int Id { get; set; }

    public int FeeGroupId { get; set; }

    public int FeeTypeId { get; set; }

    public decimal Value { get; set; }

    public virtual FeeGroup FeeGroup { get; set; } = null!;

    public virtual Feetype FeeType { get; set; } = null!;
}
