using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Core.Entities;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Services;

public class ToDoService : IToDoService
{
    private readonly AppDbContext _context;

    public ToDoService(AppDbContext context) => _context = context;

    public async Task<ToDoItemDto> CreateAsync(ToDoItemDto dto)
    {
        var item = new ToDoItem { Title = dto.Title, IsCompleted = dto.IsCompleted };
        _context.ToDoItems.Add(item);
        await _context.SaveChangesAsync();
        dto.Id = item.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var item = await _context.ToDoItems.FindAsync(id);
        if (item == null) return false;
        _context.ToDoItems.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ToDoItemDto>> GetAllAsync()
    {
        return await _context.ToDoItems
            .Select(x => new ToDoItemDto { Id = x.Id, Title = x.Title, IsCompleted = x.IsCompleted })
            .ToListAsync();
    }

    public async Task<ToDoItemDto?> GetByIdAsync(Guid id)
    {
        var x = await _context.ToDoItems.FindAsync(id);
        return x == null ? null : new ToDoItemDto { Id = x.Id, Title = x.Title, IsCompleted = x.IsCompleted };
    }

    public async Task<ToDoItemDto?> UpdateAsync(ToDoItemDto dto)
    {
        var item = await _context.ToDoItems.FindAsync(dto.Id);
        if (item == null) return null;

        item.Title = dto.Title;
        item.IsCompleted = dto.IsCompleted;
        await _context.SaveChangesAsync();
        return dto;
    }
}
