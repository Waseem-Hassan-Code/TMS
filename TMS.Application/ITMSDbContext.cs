namespace TMS.Application;
public interface ITMSDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}