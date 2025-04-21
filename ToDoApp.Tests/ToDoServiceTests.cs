using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.DTOs;
using ToDoApp.Infrastructure.Data;
using ToDoApp.Infrastructure.Services;


namespace ToDoApp.Tests;

public class ToDoServiceTests
{
    private ToDoService _service;
    private AppDbContext _context;

    public ToDoServiceTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;
        _context = new AppDbContext(options);
        _service = new ToDoService(_context);
    }

    [Fact]
    public async Task Create_Should_Add_Item()
    {
        var dto = new ToDoItemDto { Title = "Test ToDo" };
        var result = await _service.CreateAsync(dto);
        result.Title.Should().Be("Test ToDo");
        (await _service.GetAllAsync()).Should().HaveCount(1);
    }
}
