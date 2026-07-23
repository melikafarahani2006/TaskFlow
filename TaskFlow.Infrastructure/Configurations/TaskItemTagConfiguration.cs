using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Configurations;
public class TaskItemTagConfiguration : IEntityTypeConfiguration<TagTaskItem>
{
    public void Configure(EntityTypeBuilder<TagTaskItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.TaskItem)
               .WithMany(t => t.TaskTags)
               .HasForeignKey(x => x.TaskItemId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Tag)
               .WithMany(t => t.TaskTags)
               .HasForeignKey(x => x.TagId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}