using e_Tikets.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Tikets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(a => a.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie>  Movies { get; set; }
        public DbSet<Producer>  Producers { get; set; }
        public DbSet<Cienma>  Cienmes { get; set; }

    }
}
