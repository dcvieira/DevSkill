
using DevSkill.Order.Application.Contracts;
using DevSkill.Order.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Order.Persistence;
public class DevSkillDbContext : DbContext
{
    private readonly ILoggedInUserService _loggedInUserService;


    public DevSkillDbContext(DbContextOptions<DevSkillDbContext> options, ILoggedInUserService loggedInUserService)
        : base(options)
    {
        _loggedInUserService = loggedInUserService;
    }

    public DbSet<Order.Domain.Entities.Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevSkillDbContext).Assembly);

     
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

