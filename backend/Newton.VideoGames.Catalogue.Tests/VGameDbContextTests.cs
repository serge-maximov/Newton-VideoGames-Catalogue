using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newton_VideoGames_Catalogue.Data;
using Newton_VideoGames_Catalogue.Models;
using Xunit;

namespace Newton.VideoGames.Catalogue.Tests
{
    public class VGameDbContextTests
    {
        [Fact]
        public void CanRetrieveVGames()
        {
            using var context = TestDbContextFactory.Create();
            var games = context.VGames.ToList();

            Assert.Equal(2, games.Count);
            Assert.Contains(games, g => g.Title == "Halo");
            Assert.Contains(games, g => g.Title == "The Witcher 3");
        }

        [Fact]
        public void CanAddVGame()
        {
            using var context = TestDbContextFactory.Create();

            var newGame = new VGame
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Genre = "RPG",
                ReleaseYear = 2020,
                Platform = "PC",
                Description = "Sci-fi RPG",
                Price = 49.99M
            };

            context.VGames.Add(newGame);
            context.SaveChanges();

            var games = context.VGames.ToList();
            Assert.Equal(3, games.Count);
            Assert.Contains(games, g => g.Title == "Cyberpunk 2077");
        }
    }
}


