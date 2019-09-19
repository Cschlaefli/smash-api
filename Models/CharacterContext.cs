using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmashApi.Models
{
    public class CharacterContext : IdentityDbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Character> Characters {get; set;}
    }
}