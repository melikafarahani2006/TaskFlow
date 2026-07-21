using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Configurations
{
    public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
    {
        public void Configure(EntityTypeBuilder<Workspace> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(w => w.Description)
                   .HasMaxLength(500);
        }
    }
}
