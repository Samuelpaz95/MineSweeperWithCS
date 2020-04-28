using MineSweeper.gameSrc;
using System.ComponentModel.DataAnnotations;

namespace MineSweeper.Models
{
    public class TableCreator
    {
        [Required]
        public string PlayerName { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int MinesNumber { get; set; }
        public int size => Height * Width;
        public Game game => new Game(new Player(PlayerName), new Terrain(Height, Width, MinesNumber));
    }
}