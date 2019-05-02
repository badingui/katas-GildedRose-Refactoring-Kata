namespace GildedRose.Entities
{
    public abstract class AbstractItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public abstract void UpdateQuality();

        public void DecrementSellIn()
        {
            SellIn -= 1;
        }

        public override string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }
    }
}
