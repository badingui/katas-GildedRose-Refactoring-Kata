namespace GildedRose.Entities
{
    public class SulfurasHand : AbstractItem
    {
        public SulfurasHand(int sellIn, int quality, string name = "Sulfuras, Hand of Ragnaros")
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public override void UpdateQuality()
        {
            //TODO
        }
    }
}