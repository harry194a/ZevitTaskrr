using ZevitTask.Application.Models.In.Create;
using ZevitTask.Application.Models.In.Mediator;
using ZevitTask.Application.Models.In.Update;
using ZevitTask.Application.Models.Out;
using ZevitTask.Infrastructure.Out.Persistence.Repository;

namespace ZevitTaskTests.Unit;

using System;
using System.Collections.Generic;
using Xunit;
using ZevitTask.Infrastructure.Out.Service;
using Moq;

public class ContactServiceTests
{
    [Fact]
    public void GetAll_Should_Return_Contacts()
    {
        // Arrange
        var repositoryMock = new Mock<IContactRepository>();
        repositoryMock.Setup(repo => repo.GetContacts()).Returns(new List<ContactMediator>());

        var service = new ContactService(repositoryMock.Object);

        // Act
        var result = service.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void GetById_Should_Return_Contact_IfExists()
    {
        // Arrange
        var contactId = Guid.NewGuid();
        var repositoryMock = new Mock<IContactRepository>();
        repositoryMock.Setup(repo => repo.GetContactById(contactId)).Returns(new ContactMediator());

        var service = new ContactService(repositoryMock.Object);

        // Act
        var result = service.GetById(contactId);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete_Should_Remove_Contact()
    {
        // Arrange
        var contactId = Guid.NewGuid();
        var repositoryMock = new Mock<IContactRepository>();
        var service = new ContactService(repositoryMock.Object);

        // Act
        service.Delete(contactId);

        // Assert
        repositoryMock.Verify(repo => repo.DeleteContact(contactId), Times.Once);
    }

    [Fact]
    public void Create_Should_Add_New_Contact()
    {
        // Arrange
        var createRequest = new CreateContactRequest("John", "Doe", "john@example.com", "123456");
        var repositoryMock = new Mock<IContactRepository>();
        repositoryMock.Setup(repo => repo.AddContact(createRequest)).Returns(new ContactMediator());

        var service = new ContactService(repositoryMock.Object);

        // Act
        var result = service.Create(createRequest);

        // Assert
        Assert.NotNull(result);
    }
    [Fact]
    public void Update_Should_Modify_Contact()
    {
        // Arrange
        var contactId = Guid.NewGuid();
        var updateRequest = new UpdateContactRequest
        (
            "John Snow",
            "updated@example.com",
            "123456",
            "new york 3"
        );

        var repositoryMock = new Mock<IContactRepository>();
    
        // Define the return value for UpdateContact method
        repositoryMock.Setup(repo => repo.UpdateContact(It.IsAny<Guid>(), It.IsAny<UpdateContactRequest>()))
            .Returns((Guid id, UpdateContactRequest request) => 
                new ContactMediator 
                {
                    Id = id,
                    PhoneNumber = request.PhoneNumber,
                    EmailAddress = request.EmailAddress,
                    PhysicalAddress = request.PhysicalAddress,
                    FullName = request.FullName
                });

        var service = new ContactService(repositoryMock.Object);

        // Act
        var result = service.Update(updateRequest, contactId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(contactId, result.Id);
        Assert.Equal(updateRequest.FullName, result.FullName);
        Assert.Equal(updateRequest.PhysicalAddress, result.PhysicalAddress);
        Assert.Equal(updateRequest.EmailAddress, result.EmailAddress);
        Assert.Equal(updateRequest.PhoneNumber, result.PhoneNumber);
    }

}


