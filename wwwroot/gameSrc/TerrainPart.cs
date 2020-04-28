namespace MineSweeper.gameSrc
{
    public class TerrainPart
    {
        private Item Item;
        private bool Earthed;
        private bool WithPennant;

        public Item item { get => Item; }

        public TerrainPart()
        {
            Item = null;
            Earthed = true;
            WithPennant = false;
        }
        public bool IsEarthed()
        {
            return Earthed;
        }
        public bool IsWithPeannant()
        {
            return WithPennant;
        }
        public void togglePennant()
        {
            WithPennant = !WithPennant;
        }
        public void UnEarth()
        {
            Earthed = false;
        }
        public void putItem(Item item)
        {
            Item = item;
        }

        public override string ToString()
        {
            string res = "[>]";
            if (IsEarthed())
            {
                res = "[-]";
            }
            else if (!IsWithPeannant() && item != null)
            {
                res = '[' + item.ToString() + ']';
            }
            return res;
        }
    }
}