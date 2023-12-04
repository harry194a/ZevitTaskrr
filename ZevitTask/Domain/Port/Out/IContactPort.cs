using ZevitTask.Application.Models.In.Create;
using ZevitTask.Application.Models.In.Update;
using ZevitTask.Application.Models.Out;

namespace ZevitTask.Domain.Port.Out;

public interface IContactPort
{
    List<ContactResponse> GetAll();
    ContactResponse GetById(Guid id);
    void Delete(Guid id);
    ContactResponse Create(CreateContactRequest contact);
    ContactResponse Update(UpdateContactRequest contact, Guid id);
}
