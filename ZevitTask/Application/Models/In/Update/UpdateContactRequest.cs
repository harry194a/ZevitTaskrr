namespace ZevitTask.Application.Models.In.Update;

public record UpdateContactRequest(
    string FullName,
    string EmailAddress,
    string PhoneNumber,
    string PhysicalAddress
);






