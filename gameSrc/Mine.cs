using System.Collections.Generic;

namespace MineSweeper.gameSrc
{
    public class Mine : Item
    {
        public Mine(int[] Location) : base('X', Location) { }

        public override void Activate(Terrain terrain)
        {
            List<int[]> adjacentLocatons = this.CalculateAdjacent(this.location);
            foreach (int[] loc in adjacentLocatons)
            {
                Activate(terrain.SelectTerrainPart(loc));
            }
        }
        private void Activate(TerrainPart terrainPart)
        {
            if (terrainPart != null && terrainPart.item is Clue)
            {
                ((Clue)terrainPart.item).MineAdded();
            }
        }
    }
}