using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Api_MarioKart.Models
{
    public class MarioKartContext : DbContext
    {
        public MarioKartContext(DbContextOptions<MarioKartContext> options) : base(options)
        {

        }
        public DbSet<Personaggi> Personaggi { get; set; }
        public DbSet<Squadra> Squadra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Squadra>()
            .HasKey(s => new { s.SquadraId });
            modelBuilder.Entity<Personaggi>()
            .HasKey(p => new { p.PersonaggioId });

            modelBuilder.Entity<Squadra>()
            .HasMany(e => e.Personaggis)
            .WithOne(e => e.SquadraRifNavigation)
            .HasForeignKey(e => e.SquadraRif);


            modelBuilder.Entity<Personaggi>()
            .HasOne(e => e.SquadraRifNavigation)
            .WithMany(e => e.Personaggis)
            .HasForeignKey(e => e.SquadraRif);
            
        }

    }
}
