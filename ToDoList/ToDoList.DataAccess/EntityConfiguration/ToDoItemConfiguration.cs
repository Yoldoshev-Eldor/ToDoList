using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess.EntityConfiguration;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.ToTable("ToDoItem");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Title).HasMaxLength(50).IsRequired(true);
        builder.Property(i => i.Description).HasMaxLength(255).IsRequired(false);
        builder.Property(i => i.IsCompleted).IsRequired(true);
        builder.Property(i => i.CreatedAt).IsRequired(true);
        builder.Property(i => i.DueDate).IsRequired(true);
    }
}
