using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newton_VideoGames_Catalogue.Controllers;
using Newton_VideoGames_Catalogue.Data;
using Newton_VideoGames_Catalogue.Models;
using Xunit;

namespace Newton.VideoGames.Catalogue.Tests;

public class VGamesControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsVGames()
    {
        using var context = TestDbContextFactory.Create();
        var controller = new VGamesController(context);

        var result = await controller.GetAll();

        /* returned ActionResult<IEnumerable<VGame>> wraps a Result property */
        var okResult = Assert.IsType<OkObjectResult>(result);  /* check the result */
        var games = Assert.IsAssignableFrom<IEnumerable<VGame>>(okResult.Value);

        Assert.Equal(2, games.Count()); /* matches the  data  */
        Assert.Contains(games, g => g.Title == "Halo");
        Assert.Contains(games, g => g.Title == "The Witcher 3");
    }
}
