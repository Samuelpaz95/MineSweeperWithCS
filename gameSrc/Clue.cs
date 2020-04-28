using System;
using System.Collections.Generic;

namespace MineSweeper.gameSrc
{
    public class Clue : Item
    {
        private int Number;
        private bool Active;

        public int number { get => Number; }
        private bool isActive { get => Active; }

        public Clue(int[] Location) : base(' ', Location)
        {
            this.Number = 0;
            this.Active = false;
        }
        public void MineAdded()
        {
            Number++;
            symbol = Number.ToString()[0];
        }
        public int CountPennantsAround(Terrain terrain)
        {
            int count = 0;
            List<int[]> adjacentLocatons = this.CalculateAdjacent(this.location);
            TerrainPart terrainPart;
            foreach (int[] loc in adjacentLocatons)
            {
                terrainPart = terrain.SelectTerrainPart(loc);
                count += terrainPart != null && terrainPart.IsWithPeannant() ? 1 : 0;
            }
            return count;
        }
        public override void Activate(Terrain terrain)
        {
            this.Active = true;
            List<int[]> adjacentLocatons = this.CalculateAdjacent(this.location);
            foreach (int[] loc in adjacentLocatons)
            {
                Activate(terrain.SelectTerrainPart(loc), terrain);
            }
            this.Active = false;
        }

        private void Activate(TerrainPart terrainPart, Terrain terrain)
        {
            if ((terrainPart != null))
            {
                if (Activatable(terrainPart, terrain))
                {
                    terrainPart.item.Activate(terrain);
                }
                terrainPart.UnEarth();
            }
        }
        public bool Activatable(TerrainPart terrainPart, Terrain terrain)
        {
            Clue clue = (Clue) terrainPart.item;
            bool res = !terrainPart.IsWithPeannant();
            res = res && (clue.number == 0 && terrainPart.IsEarthed() ||
                          clue.number == clue.CountPennantsAround(terrain) &&
                          clue.number > 0);
            res = res && !clue.isActive;

            return res;
        }
    }
}