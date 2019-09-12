using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmashApi.Models
{
    public class CharacterContext : IdentityDbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options) { }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Character> Characters {get; set;}
    }
}