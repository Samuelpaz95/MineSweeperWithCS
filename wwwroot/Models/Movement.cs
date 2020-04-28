using System.ComponentModel.DataAnnotations;

namespace MineSweeper.Models
{
    public class Movement
    {
        [Required]
        public int X { get; set;}
        [Required]
        public int Y { get; set;}
    }
}