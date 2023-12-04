using ZevitTask.Domain.Model;

namespace ZevitTask.Application.Models.Out;

public class ContactResponse
{
    public Guid? Id { get; set; }
    public string? FullName{ get; set; }
    public string? EmailAddress{ get; set; }
    public string? PhoneNumber{ get; set; }
    public string? PhysicalAddress{ get; set; }

    public static ContactResponse From(Contact contact)
    {
        var contactResponse = new ContactResponse
        {
            Id = contact.Id,
            FullName = contact.FullName,
            EmailAddress = contact.EmailAddress,
            PhoneNumber = contact.PhoneNumber,
            PhysicalAddress = contact.PhysicalAddress
        };
        
        return contactResponse;
    }
    
    public static List<ContactResponse> From(List<Contact> list)
    {
        {
            var responseList = new List<ContactResponse>();
            foreach (var items in list)
            {
                responseList.Add(From(items));
            }
            return responseList;
        }
    }
}