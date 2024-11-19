using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities.Identity;
using TMS.Application;
using TMS.Domain;

namespace TMS.Infrastructure;

public class TMSDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>
    , ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, ApplicationUserToken>, ITMSDbContext
{
    private readonly IConfiguration _configuration;

    public TMSDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), sqlServerOptions =>
            {
                sqlServerOptions.CommandTimeout(300);
                sqlServerOptions.MigrationsAssembly(typeof(TMSDbContext).Assembly.FullName);
            });
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Task)
            .WithMany(t => t.Assignments)
            .HasForeignKey(a => a.TaskId);

        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.AssignedTo)
            .WithMany(u => u.Assignments)
            .HasForeignKey(a => a.AssignedToUserId);

        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.AssignedBy)
            .WithMany()
            .HasForeignKey(a => a.AssignedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Task)
            .WithMany(t => t.Comments)
            .HasForeignKey(c => c.TaskId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId);

        modelBuilder.Entity<TaskHistory>()
            .HasOne(th => th.Task)
            .WithMany(t => t.TaskHistories)
            .HasForeignKey(th => th.TaskId);

        modelBuilder.Entity<TaskHistory>()
            .HasOne(th => th.PerformedBy)
            .WithMany(u => u.TaskHistories)
            .HasForeignKey(th => th.PerformedByUserId);
    }

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}