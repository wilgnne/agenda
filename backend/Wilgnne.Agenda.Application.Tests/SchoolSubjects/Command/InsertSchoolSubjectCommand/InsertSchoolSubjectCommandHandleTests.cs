using FakeItEasy;
using FluentAssertions;

using Wilgnne.Agenda.Application.SchoolSubjects.Command.InsertSchoolSubjectCommand;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Application.Tests;

public class InsertSchoolSubjectCommandHandleTests
{
    private readonly InsertSchoolSubjectCommandHandle _service;
    private readonly IRepository<SchoolSubject> _repository;

    public InsertSchoolSubjectCommandHandleTests()
    {
        // Dependencies
        _repository = A.Fake<IRepository<SchoolSubject>>();

        // SUT
        _service = new InsertSchoolSubjectCommandHandle(_repository);
    }

    [Fact]
    public async Task InsertSchoolSubject_ReturnSchoolSubject()
    {
        // Arrange
        var subject = "new subject";
        var userId = Guid.NewGuid();
        A.CallTo(_repository)
        .WithReturnType<Task<SchoolSubject>>()
        .Returns(Task.FromResult(new SchoolSubject(userId, subject)));

        //Act
        var result = await _service.Handle(
            new InsertSchoolSubjectCommand(userId, subject),
            new CancellationToken()
        );

        //Assert
        result.Should().NotBeNull();
        result.Subject.Should().Be(subject);
    }
}
