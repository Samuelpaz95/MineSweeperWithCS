using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.gameSrc
{
    public class Game
    {
        private Player Player;
        private Terrain Terrain;
        public Game(Player player, Terrain terrain)
        {
            this.Player = player;
            this.Terrain = terrain;
        }
        public void do_movement(int[] location, string action)
        {
            TerrainPart terrainPart = Terrain.SelectTerrainPart(location);
            if (terrainPart.item == null) {
                PutClues();
                PutMines(location);
            }
            if (action.Equals("unearth"))
            {
                Player.Play(Terrain, location);
            }
            else if (action.Equals("pennant"))
            {
                Player.TogglePennantIn(Terrain, location);
            }
        }
        private void PutClues()
        {
            int[] location;
            int x, y;
            int height = Terrain.Shape()[0];
            int width = Terrain.Shape()[1];
            for (int part = 0; part < Terrain.Size(); part++)
            {
                x = (part / width) % height;
                y = (part % width);
                location = new int[] { x, y };
                Terrain.SelectTerrainPart(location).putItem(new Clue(location));
            }
        }
        private void PutMines(int[] location)
        {
            List<int[]> BlockedLocations = new List<int[]>();
            BlockedLocations.Add(location);
            TerrainPart terrainPart;
            for (int i = 0; i < Terrain.mineNumber; i++)
            {
                location = createNewLocation(BlockedLocations, Terrain);
                terrainPart = Terrain.SelectTerrainPart(location);
                terrainPart.putItem(new Mine(location));
                terrainPart.item.Activate(Terrain);
                BlockedLocations.Add(location);
            }
        }

        private int[] createNewLocation(List<int[]> blockedLocations, Terrain terrain)
        {
            int index = 0;
            int[] location;
            do
            {
                location = createRamdomLocation(terrain);
                index = blockedLocations.FindIndex(
                    l => Enumerable.SequenceEqual(location, l)
                );
            } while (index != -1);
            return location;
        }

        private int[] createRamdomLocation(Terrain terrain)
        {
            int height = terrain.Shape()[0];
            int width = terrain.Shape()[1];
            Random random = new Random();
            int x = random.Next(0, height);
            int y = random.Next(0, width);
            return new int[] { x, y };
        }

        public string[] PrintTable()
        {
            List<string> strList = new List<string>();
            string str = Terrain.ToString();
            str = str.Replace("\n", "");
            for (int i = 0; i < str.Length - 1; i = i + 3)
            {
                strList.Add(str.Substring(i, 3));
            }
            return strList.ToArray();
        }
        public bool LivePlayer(){
            return Player.isAlive;
        }
    }
}