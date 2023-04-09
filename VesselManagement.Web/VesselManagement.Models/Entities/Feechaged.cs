using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Models.Entities;

public partial class Feechaged : IBaseEntity
{
    public int Id { get; set; }

    public int FeeStatusId { get; set; }

    public virtual FeeChargedStatus FeeStatus { get; set; } = null!;
}
