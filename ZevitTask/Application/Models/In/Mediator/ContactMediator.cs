using ZevitTask.Domain.Model;
using ZevitTask.Infrastructure.Out.Persistence.Entity;

namespace ZevitTask.Application.Models.In.Mediator;

public class ContactMediator
{
    public Guid Id { get; set; }
    public string? FullName{ get; set; }
    public string? EmailAddress{ get; set; }
    public string? PhoneNumber{ get; set; }
    public string? PhysicalAddress{ get; set; }

    public static ContactMediator From(ContactEntity contact)
    {
        var contactResponse = new ContactMediator();
        contactResponse.Id = contact.Id;
        contactResponse.FullName = contact.FullName;
        contactResponse.EmailAddress = contact.EmailAddress;
        contactResponse.PhoneNumber = contact.PhoneNumber;
        contactResponse.PhysicalAddress = contact.PhysicalAddress;
        return contactResponse;
    }
    public static ContactEntity ToEntity(ContactMediator contact)
    {
        var contactResponse = new ContactEntity();
        contactResponse.Id = contact.Id;
        contactResponse.FullName = contact.FullName;
        contactResponse.EmailAddress = contact.EmailAddress;
        contactResponse.PhoneNumber = contact.PhoneNumber;
        contactResponse.PhysicalAddress = contact.PhysicalAddress;
        return contactResponse;
    }
    
    public static Contact ToContact(ContactMediator contact)
    {
        var contactResponse = new Contact();
        contactResponse.Id = contact.Id;
        contactResponse.FullName = contact.FullName;
        contactResponse.EmailAddress = contact.EmailAddress;
        contactResponse.PhoneNumber = contact.PhoneNumber;
        contactResponse.PhysicalAddress = contact.PhysicalAddress;
        return contactResponse;
    }
    public static List<ContactMediator> From(List<ContactEntity> list)
    {
        {
            var responseList = new List<ContactMediator>();
            foreach (var items in list)
            {
                responseList.Add(From(items));
            }
            return responseList;
        }
    }
    
    public static List<Contact> ToContact(List<ContactMediator> list)
    {
        {
            var responseList = new List<Contact>();
            foreach (var items in list)
            {
                responseList.Add(ToContact(items));
            }
            return responseList;
        }
    }
}