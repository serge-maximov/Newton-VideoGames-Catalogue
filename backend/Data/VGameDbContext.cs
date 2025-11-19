using Newton_VideoGames_Catalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace Newton_VideoGames_Catalogue.Data
{
    public class VGameDbContext : DbContext
    {
        public VGameDbContext(DbContextOptions<VGameDbContext> options) : base(options) { }

        public DbSet<VGame> VGames => Set<VGame>();
    }
}
