using MineSweeper.gameSrc;
namespace MineSweeper.Models
{
    public class GameState
    {
        private static Game game;

        internal static Game Game { get => game; set => game = value; }
        public string PlayerName { get; set; }
        public bool LivePlayer {get; set; }
        public string[] Table { get; set; }
        public GameState(){}
        public void Notify()
        {
            Table = Game.PrintTable();
            LivePlayer = Game.LivePlayer();
        }
    }
}