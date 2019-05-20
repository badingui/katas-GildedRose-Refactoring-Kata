namespace GildedRose.Entities
{
    public class Conjured : AbstractItem
    {
        public Conjured(int sellIn, int quality, string name = "Conjured Mana Cake")
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 2;
            }

            DecrementSellIn();

            if (SellIn < 0 && Quality > 0)
            {
                Quality -= 2;
				//Dd
            }
        }
    }
}