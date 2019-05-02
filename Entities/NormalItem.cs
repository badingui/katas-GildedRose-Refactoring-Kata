namespace GildedRose.Entities
{
    public class NormalItem: AbstractItem
    {
        public NormalItem(int sellIn, int quality, string name = "Conjured")
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 1;
            }

            DecrementSellIn();

            if (SellIn < 0 && Quality > 0)
            {
                Quality -= 1;
            }
        }
    }
}
