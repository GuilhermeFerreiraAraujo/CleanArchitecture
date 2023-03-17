﻿
public partial class Contact
{
    public int Id { get; set; }

    public int EntityId { get; set; }

    public int EntityTypeId { get; set; }

    public int ContactTypeId { get; set; }

    public string Value { get; set; } = null!;

    public bool IsMainContact { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public virtual ContactType ContactType { get; set; } = null!;

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual User? UpdateByNavigation { get; set; }
}


