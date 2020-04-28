using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MineSweeper.Models;
using MineSweeper.gameSrc;

namespace MineSweeper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameStateController : ControllerBase
    {
        public static GameState GameState = new GameState();
        [HttpGet]
        public ActionResult<GameState> GetState()
        {
            var gameState = GameState;
            if (gameState == null)
            {
                return NotFound();
            }
            return gameState;
        }

        
        [HttpPost]
        public ActionResult<GameState> CreateTable(TableCreator tableCreator){
            
            GameState.Game = tableCreator.game;
            GameState.PlayerName = tableCreator.PlayerName;
            GameState.Notify();
            return CreatedAtAction(nameof(GetState), GameState);
        }
        [HttpPost("{unearth}")]
        public ActionResult<GameState> Unearth(Movement movement){
            int[] location = new int[] {movement.X, movement.Y};
            GameState.Game.do_movement(location, "unearth");
            GameState.Notify(); 
            return CreatedAtAction(nameof(GetState), GameState);
        }
    }
}