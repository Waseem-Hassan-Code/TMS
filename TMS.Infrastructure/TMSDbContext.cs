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
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("IdentityConnection"), sqlServerOptions =>
            {
                sqlServerOptions.CommandTimeout(300);
                sqlServerOptions.MigrationsAssembly(typeof(TMSDbContext).Assembly.FullName);
            });
        }

        base.OnConfiguring(optionsBuilder);
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
