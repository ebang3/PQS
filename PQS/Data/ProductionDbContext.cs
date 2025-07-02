using Microsoft.EntityFrameworkCore;
using PQS.Models;

public class ProductionDbContext : DbContext
{
    public ProductionDbContext(DbContextOptions<ProductionDbContext> options)
        : base(options) { }

    public DbSet<IMM_MoldPresets> IMM_MoldPresets { get; set; }
}
