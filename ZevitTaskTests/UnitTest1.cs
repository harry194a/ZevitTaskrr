using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using ZevitTask.Application.comm;
using ZevitTask.Application.Models.In.Create;
using ZevitTask.Infrastructure.Out.Persistence.Repository;
using ZevitTask.Infrastructure.Out.Service;

namespace ZevitTaskTests;

public class UnitTest1
{
    [Fact]
    private void Test()
    {
        var repository = new ContactRepository(BuildDbContext());
        var service = new ContactService(repository);

        service.Create(new CreateContactRequest
        (

             "test",
             "test",
            "test",
             "test"
        ));

        var result = service.GetAll();
        
        Assert.NotEmpty(result);
    }
    
    private AppDbContext BuildDbContext()
    {


        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("test")
            .Options;

        return new AppDbContext(options);
    }
}