using Microsoft.EntityFrameworkCore;

namespace RoleBased.Infractructure.Presistance;

public class RoleBasedDbContext : DbContext
{
    public RoleBasedDbContext(DbContextOptions<RoleBasedDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleBasedDbContext).Assembly);
    }
}
