using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<Workspace> Workspaces => Set<Workspace>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<TaskList> TaskLists => Set<TaskList>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TagTaskItem> TaskItemTags => Set<TagTaskItem>();
        public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
        public DbSet<WorkspaceMember> WorkspaceMembers => Set<WorkspaceMember>();
        public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
