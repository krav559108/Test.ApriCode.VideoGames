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
    private static List<GamesList> games = new List<GamesList>
            {
                new GamesList
                {
                    GameId = 1,
                    Title = "FIFA 22",
                    DeveloperStudioId = 1,
                    DeveloperStudio = "EA Sports",
                    Genre = "Sports"
                },
                new GamesList
                {
                    GameId = 2,
                    Title = "Call of Duty: Warzone",
                    DeveloperStudioId = 2,
                    DeveloperStudio = "Infity Ward",
                    Genre = "Multiplayer"
                },
                new GamesList
                {
                    GameId = 3,
                    Title = "Call of Duty: Modern Warfare 3",
                    DeveloperStudioId = 2,
                    DeveloperStudio = "Infity Ward",
                    Genre = "FPS"
                },
                new GamesList
                {
                    GameId = 4,
                    Title = "World of Warcraft",
                    DeveloperStudioId = 3,
                    DeveloperStudio = "Blizzard Entertainment",
                    Genre = "Multiplayer"
                }
            };

    // GET: api/values
    [HttpGet]
    public async Task<ActionResult<List<GamesList>>> Get()
    {
        return Ok(games);
    }

    // GET api/values/5
    [HttpGet("{GameId}")]
    public async Task<ActionResult<List<GamesList>>> GetId(int id)
    {
        var game = games.Find(g => g.GameId == id);
        if (game == null)
            return BadRequest("Game not found");
        return Ok(game);
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<List<GamesList>>> AddGame(GamesList game)
    {
        games.Add(game);
        return Ok(games);
    }

    // PUT api/values/5
    [HttpPut("{GameId}")]
    public async Task<ActionResult<List<GamesList>>> UpdateGame(GamesList updateRequest)
    {
        var game = games.Find(g => g.GameId == updateRequest.GameId);
        if (game == null)
            return BadRequest("Game not found");

        game.GameId = updateRequest.GameId;
        game.Title = updateRequest.Title;
        game.DeveloperStudio = updateRequest.DeveloperStudio;
        game.DeveloperStudioId = updateRequest.DeveloperStudioId;
        game.Genre = updateRequest.Genre;

        return Ok(games);

    }

    // DELETE api/values/5
    [HttpDelete("{GameId}")]
    public async Task<ActionResult<List<GamesList>>> DeleteGame(GamesList deleteGame)
    {
        var game = games.Find(g => g.GameId == deleteGame.GameId);
        if (game == null)
            return BadRequest("Game not found");
        games.Remove(game);
        return Ok(game);
    }
}

