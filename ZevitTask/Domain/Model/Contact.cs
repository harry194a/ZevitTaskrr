using System.ComponentModel.DataAnnotations;

namespace ZevitTask.Domain.Model;

public class Contact
{
    public Guid? Id{ get; set; }
    public string? FullName{ get; set; }
    public string? EmailAddress{ get; set; }
    public string? PhoneNumber{ get; set; }
    public string? PhysicalAddress{ get; set; }
}
