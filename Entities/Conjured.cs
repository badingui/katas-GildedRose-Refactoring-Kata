namespace csharp.Entities
{
    public class Conjured : Item
    {
        public Conjured(int sellIn, int quality, string name = "Conjured")
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 2;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0 && Quality > 0)
            {
                Quality = Quality - 2;
            }
        }
    }
}