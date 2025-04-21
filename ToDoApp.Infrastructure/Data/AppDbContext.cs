using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Entities;

namespace ToDoApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
