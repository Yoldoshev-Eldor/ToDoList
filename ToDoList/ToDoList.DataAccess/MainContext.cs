using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.EntityConfigurations;

namespace ToDoList.DataAccess;

public class MainContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems { get; set; }
    public DbSet<User> Users { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
    }
}