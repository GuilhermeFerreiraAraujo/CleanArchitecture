using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class Feechaged
{
    public int Id { get; set; }

    public int FeeStatusId { get; set; }

    public virtual FeeChargedStatus FeeStatus { get; set; } = null!;
}
