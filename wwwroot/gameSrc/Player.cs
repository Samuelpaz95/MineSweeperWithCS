namespace MineSweeper.gameSrc
{
    public class Player
    {
        private string Name;
        private bool Alive;
        public bool isAlive { get => Alive; }
        public string name { get => Name; }

        public Player(string name)
        {
            Name = name;
            Alive = true;
        }
        public void Play(Terrain terrain, int[] location)
        {
            TerrainPart terrainPart = terrain.SelectTerrainPart(location);
            Item item = terrainPart.item;
            if (item is Mine)
            {
                kill();
            }
            else if (((Clue)item).Activatable(terrainPart, terrain))
            {
                item.Activate(terrain);
            }
            ScratchTerrain(terrainPart);
        }
        private void ScratchTerrain(TerrainPart terrainPart)
        {
            bool done = !terrainPart.IsWithPeannant() && terrainPart.IsEarthed();
            if (done)
            {
                terrainPart.UnEarth();
            }
        }
        public void TogglePennantIn(Terrain terrain, int[] location)
        {
            terrain.SelectTerrainPart(location).togglePennant();
        }
        private void kill()
        {
            this.Alive = false;
        }
    }
}