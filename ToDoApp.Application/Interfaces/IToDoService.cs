using ToDoApp.Application.DTOs;

namespace ToDoApp.Application.Interfaces;

public interface IToDoService
{
    Task<IEnumerable<ToDoItemDto>> GetAllAsync();
    Task<ToDoItemDto?> GetByIdAsync(Guid id);
    Task<ToDoItemDto> CreateAsync(ToDoItemDto item);
    Task<ToDoItemDto?> UpdateAsync(ToDoItemDto item);
    Task<bool> DeleteAsync(Guid id);
}
