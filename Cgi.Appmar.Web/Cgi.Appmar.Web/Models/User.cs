using System;
using System.Collections.Generic;

namespace Cgi.Appmar.Web.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public virtual ICollection<Activity> ActivityCreatedByNavigations { get; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityUpdateByNavigations { get; } = new List<Activity>();

    public virtual ICollection<Address> AddressCreatedByNavigations { get; } = new List<Address>();

    public virtual ICollection<Address> AddressUpdateByNavigations { get; } = new List<Address>();

    public virtual ICollection<Approval> Approvals { get; } = new List<Approval>();

    public virtual ICollection<Contact> ContactCreatedByNavigations { get; } = new List<Contact>();

    public virtual ICollection<Contact> ContactUpdateByNavigations { get; } = new List<Contact>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Document> DocumentCreatedByNavigations { get; } = new List<Document>();

    public virtual ICollection<Document> DocumentUpdatedByNavigations { get; } = new List<Document>();

    public virtual ICollection<User> InverseCreatedByNavigation { get; } = new List<User>();

    public virtual ICollection<User> InverseUpdateByNavigation { get; } = new List<User>();

    public virtual ICollection<Organization> OrganizationCreatedByNavigations { get; } = new List<Organization>();

    public virtual ICollection<Organization> OrganizationUpdateByNavigations { get; } = new List<Organization>();

    public virtual User? UpdateByNavigation { get; set; }

    public virtual ICollection<Vessel> VesselCreatedByNavigations { get; } = new List<Vessel>();

    public virtual ICollection<Vessel> VesselUpdateByNavigations { get; } = new List<Vessel>();
}
