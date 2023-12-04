using ZevitTask.Application.Models.In.Mediator;

namespace ZevitTask.Application.Models.In.Create;

public record CreateContactRequest(
    string FullName,
    string EmailAddress,
    string PhoneNumber,
    string PhysicalAddress
)
{
  public static ContactMediator ToMediator(CreateContactRequest createContactRequest)
    {
        var contact = new ContactMediator();
        contact.FullName = createContactRequest.FullName;
        contact.EmailAddress = createContactRequest.EmailAddress;
        contact.PhoneNumber = createContactRequest.PhoneNumber;
        contact.PhysicalAddress = createContactRequest.PhysicalAddress;
        return contact;
    }
}