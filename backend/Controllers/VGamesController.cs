using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newton_VideoGames_Catalogue.Data;
using Newton_VideoGames_Catalogue.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;

namespace Newton_VideoGames_Catalogue.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class VGamesController : ControllerBase
    {
        private readonly VGameDbContext _dbContext;
        public VGamesController(VGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _dbContext.VGames.ToListAsync());

       [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var vgame = await _dbContext.VGames.FindAsync(id);
            return vgame == null ? NotFound() : Ok(vgame);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VGame vgame)
        {
            _dbContext.Add(vgame);
            await _dbContext.SaveChangesAsync();
            return Created($"api/vgames/{vgame.Id}", vgame);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, VGame updated)
        {
            var vgame = await _dbContext.VGames.FindAsync(id);
            if(vgame == null) 
                return NotFound();

            vgame.Title = updated.Title;
            vgame.Genre = updated.Genre; 
            vgame.ReleaseYear = updated.ReleaseYear;
            vgame.Platform = updated.Platform;
            vgame.Description = updated.Description;    
            vgame.Rating = updated.Rating; 
            vgame.Price = updated.Price;
            await _dbContext.SaveChangesAsync();

            return Ok(vgame);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _dbContext.VGames.FindAsync(id);
            if (game is null)
                return NotFound();

            _dbContext.VGames.Remove(game);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }     
}
