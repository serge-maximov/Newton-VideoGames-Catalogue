using Newton_VideoGames_Catalogue.Models;

namespace Newton_VideoGames_Catalogue.Data
{
    public class VGameProvider
    {
        public static void Provide(VGameDbContext db)
        {
            if (!db.VGames.Any())
            {
                db.VGames.AddRange(
                new VGame { Title = "Half‑Life 2", Genre = "FPS", ReleaseYear = 2004, Platform = "PC", Price = 100.00M, Rating = "PG" },
                new VGame { Title = "Witcher 3", Genre = "Action", ReleaseYear = 2015, Platform = "PS5", Price = 50.00M, Rating = "M17+" },
                new VGame { Title = "Minecraft", Genre = "Sandbox", ReleaseYear = 2011, Platform = "PC", Price = 40.00M, Rating = "M10+" },
                new VGame { Title = "Red Dead Redemption", Genre = "Action", ReleaseYear = 2018, Platform = "XBox", Price = 70.00M, Rating = "M17+" },
                new VGame { Title = "Elden Ring", Genre = "Action", ReleaseYear = 2023, Platform = "PS4", Price = 800.00M, Rating = "M17+" }
                );
                db.SaveChanges();
            }
        }
    }
}
