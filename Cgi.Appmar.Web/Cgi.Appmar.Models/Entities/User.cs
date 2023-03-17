
public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UpdateBy { get; set; }

    public virtual ICollection<Contact> ContactCreatedByNavigations { get; } = new List<Contact>();

    public virtual ICollection<Contact> ContactUpdateByNavigations { get; } = new List<Contact>();

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<User> InverseCreatedByNavigation { get; } = new List<User>();

    public virtual ICollection<User> InverseUpdateByNavigation { get; } = new List<User>();

    public virtual User? UpdateByNavigation { get; set; }
}
