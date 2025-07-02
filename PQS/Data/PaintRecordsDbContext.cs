using Microsoft.EntityFrameworkCore;
using PQS.Models;

public class PaintRecordsDbContext : DbContext
{
    public PaintRecordsDbContext(DbContextOptions<PaintRecordsDbContext> options)
        : base(options) { }
    public DbSet<FOLOMoldCheck> FOLOMoldCheck { get; set; }
    public DbSet<FOLOChecks> FOLOChecks { get; set; }
    public DbSet<FOLOPartChecks> FOLOPartChecks { get; set; }
    public DbSet<FOLOPart_Defect> FOLOPart_Defect { get; set; }
    public DbSet<FOLOPart_Defect_LO> FOLOPart_Defect_LO { get; set; }
    //public DbSet<Molding_ImagesStyles> Molding_ImagesStyles { get; set; }
}
