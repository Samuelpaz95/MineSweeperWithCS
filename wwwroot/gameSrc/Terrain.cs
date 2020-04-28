namespace MineSweeper.gameSrc
{
    public class Terrain
    {
        private static Terrain _instance = null;
        private int MineNumber;
        private TerrainPart[,] Surface;
        private bool Cleaned;
        public int mineNumber { get => MineNumber; }
        public Terrain(int height, int width, int mineNumber)
        {
            MineNumber = mineNumber;
            Surface = BuildSurface(height, width);
            Cleaned = false;
        }
        private TerrainPart[,] BuildSurface(int height, int width)
        {
            TerrainPart[,] surface = new TerrainPart[height, width];
            int i, j;
            for (int surfacePart = 0; surfacePart < height * width; surfacePart++)
            {
                i = (surfacePart / width) % height;
                j = surfacePart % width;
                surface[i, j] = new TerrainPart();
            }
            return surface;
        }
        private bool IsValid(int[] location)
        {
            int x = location[0];
            int y = location[1];
            return x >= 0 &&
                   y >= 0 &&
                   x < Surface.GetLength(0) &&
                   y < Surface.GetLength(1);
        }
        public TerrainPart SelectTerrainPart(int[] location)
        {
            TerrainPart terrainPart = null;
            if (IsValid(location))
            {
                terrainPart = Surface[location[0], location[1]];
            }
            return terrainPart;
        }
        public bool IsCleaned()
        {
            return Cleaned;
        }
        public override string ToString()
        {
            string outString = "";
            int i, j;
            int height = Surface.GetLength(0);
            int width = Surface.GetLength(1);
            for (int terraPart = 0; terraPart < Surface.Length; terraPart++)
            {
                i = (terraPart / width) % height;
                j = terraPart % width;
                outString += Surface[i, j].ToString();
                if (j == width - 1)
                {
                    outString += "\n";
                }
            }
            return outString;
        }
        public int[] Shape()
        {
            int height = Surface.GetLength(0);
            int width = Surface.GetLength(1);
            return new int[] { height, width };
        }
        public int Size()
        {
            return Shape()[0] * Shape()[1];
        }
        public static Terrain Instance(int height, int width, int mineNumber)
        {
            if (_instance == null)
            {
                _instance = new Terrain(height, width, mineNumber);
            }
            return _instance;
        }
    }
}