using System.Collections.Generic;
using System;

namespace MineSweeper.gameSrc
{
    public abstract class Item
    {
        private char Symbol;
        private int[] Location;
        public Item(char Symbol, int[] Location)
        {
            this.Symbol = Symbol;
            this.Location = Location;
        }
        protected char symbol { get => Symbol; set => Symbol = value; }
        protected int[] location { get => Location; set => Location = value; }

        public abstract void Activate(Terrain terrain);

        protected List<int[]> CalculateAdjacent(int[] Location)
        {
            List<int[]> AdjacentLocatons = GenerateDirections();
            int x, y;
            for (int i = 0; i < AdjacentLocatons.Count; i++)
            {
                x = Location[0] + AdjacentLocatons[i][0];
                y = Location[1] + AdjacentLocatons[i][1];
                AdjacentLocatons[i] = new int[] { x, y };
            }
            return AdjacentLocatons;
        }
        private List<int[]> GenerateDirections()
        {
            List<int[]> Directions = new List<int[]>();
            int i, j; //direction vector
            for (int k = 1; k <= 8; k++)
            {
                double angle = k * (Math.PI / 4);
                i = (int)Math.Round(Math.Cos(angle));
                j = (int)Math.Round(Math.Sin(angle));
                Directions.Add(new int[] { i, j });
            }
            return Directions;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }

    }
}