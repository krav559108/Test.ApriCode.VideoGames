using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.ApriCode.VideoGames.Models;

namespace Test.ApriCode.VideoGames.Controllers;

[Route("api/[controller]")]
[ApiController]


public class GamesController : Controller
{
    
    private readonly DataContext context;

    public GamesController(DataContext context)
    {
        this.context = context;
    }



    // GET: api/values
    
    [HttpGet]
    public async Task<ActionResult<List<GamesList>>> Get()
    {
        return Ok(await context.GamesLists.ToListAsync());
    }

    // GET api/values/

    [HttpGet("{GameId}")]
    public async Task<ActionResult<List<GamesList>>> GetId(int GameId)
    {
        var dbgame = await context.GamesLists.FindAsync(GameId);
        if (dbgame == null)
            return BadRequest("Game not found");
        return Ok(dbgame);
    }

    // GET api/values/

    [HttpGet("get/{GenreId}")]
    
    public async Task<ActionResult<List<GamesList>>> GetGenre(int GenreId)
    {
        //var dbgenres = await context.GamesLists.FindAsync(GenreId);
        //if (dbgenres == null)
        //    return BadRequest("Game not found");

        //return Ok(dbgenres);
        var genre_Ids = context.GamesLists.Select(s => s.GenreId == GenreId).ToList();

        var genres = await context.GamesLists.Where(t => genre_Ids.Contains(true)).ToListAsync();

        return Ok(genres);
    }

    // POST api/values
    // LEAVE GameID equal 0 when adding new game to database

    [HttpPost]
    public async Task<ActionResult<List<GamesList>>> AddGame(GamesList game)
    {
        context.GamesLists.Add(game);
        await context.SaveChangesAsync();

        return Ok(await context.GamesLists.ToListAsync());
    }

    // PUT api/values/
    [HttpPut("{GameId}")]
    public async Task<ActionResult<List<GamesList>>> UpdateGame(GamesList updateRequest)
    {
        var dbgame = await context.GamesLists.FindAsync(updateRequest.GameId);
        if (dbgame == null)
            return BadRequest("Game not found");

        dbgame.GameId = updateRequest.GameId;
        dbgame.Title = updateRequest.Title;
        dbgame.DeveloperStudio = updateRequest.DeveloperStudio;
        dbgame.DeveloperStudioId = updateRequest.DeveloperStudioId;
        dbgame.Genre = updateRequest.Genre;
        dbgame.GenreId = updateRequest.GenreId;

       
        await context.SaveChangesAsync();

        return Ok(await context.GamesLists.ToListAsync());

    }

    // DELETE api/values/
    [HttpDelete("{GameId}")]
    public async Task<ActionResult<List<GamesList>>> DeleteGame(int GameId)
    {
        var dbgame = await context.GamesLists.FindAsync(GameId);
        if (dbgame == null)
            return BadRequest("Game not found");

        context.GamesLists.Remove(dbgame);
        await context.SaveChangesAsync();

        return Ok(await context.GamesLists.ToListAsync());
    }
}

