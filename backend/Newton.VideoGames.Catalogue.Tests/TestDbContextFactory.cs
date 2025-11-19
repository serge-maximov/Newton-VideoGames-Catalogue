using System;
using Microsoft.EntityFrameworkCore;
using Newton_VideoGames_Catalogue.Data;
using Newton_VideoGames_Catalogue.Models;

namespace Newton.VideoGames.Catalogue.Tests;

/* to keep tests clean */
public static class TestDbContextFactory
{
    public static VGameDbContext Create()
    {
        var options = new DbContextOptionsBuilder<VGameDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new VGameDbContext(options);

        /* Seed test data  */
        context.VGames.AddRange(
            new VGame { Id = 1, Title = "Halo", Genre = "FPS", ReleaseYear = 2001, Platform = "Xbox", Description = "A sci-fi shooter", Rating = "M", Price = 59.99M },
            new VGame { Id = 2, Title = "The Witcher 3", Genre = "RPG", ReleaseYear = 2015, Platform = "PC", Description = "Open-world fantasy RPG", Rating = "M", Price = 39.99M }
        );

        context.SaveChanges();
        return context;
    }
}


