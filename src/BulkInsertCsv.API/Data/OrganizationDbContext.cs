using BulkInsertCsv.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BulkInsertCsv.API.Data;

public class OrganizationDbContext : DbContext
{

    public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options)
    {

    }

    public DbSet<OrganizationModel> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

