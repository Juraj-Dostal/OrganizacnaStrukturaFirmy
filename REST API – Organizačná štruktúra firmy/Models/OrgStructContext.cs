using Microsoft.EntityFrameworkCore;

namespace REST_API___Organizačná_štruktúra_firmy.Models
{
    public class OrgStructContext : DbContext
    {

        public OrgStructContext(DbContextOptions<OrgStructContext> options) : base(options)
        {

        }

        public DbSet<Uzol> Uzly { get; set; } = null!;
        public DbSet<Zamestnanec> Zamestnanci { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Uzol>().ToTable("Uzol");
            modelBuilder.Entity<Zamestnanec>().ToTable("Zamestnanec");
        }
    } 
}
