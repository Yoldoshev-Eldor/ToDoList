using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess.EntityConfigurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Description).HasMaxLength(251);
        builder.Property(t => t.IsCompleted).IsRequired();
        builder.Property(t => t.CreatedAt).IsRequired();
    }
}