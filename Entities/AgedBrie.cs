namespace csharp.Entities
{
    public class AgedBrie : Item
    {
        public AgedBrie(int sellIn, int quality, string name = "Aged Brie")
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0 && Quality < 50)
            {
                Quality = Quality + 1;
            }
        }
    }
}