using Microsoft.EntityFrameworkCore;

namespace SmashApi.Models
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options) { }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Character> Characters {get; set;}
    }
}