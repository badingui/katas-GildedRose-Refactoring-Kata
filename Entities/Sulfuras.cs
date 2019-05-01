namespace csharp.Entities
{
    public class SulfurasHand : Item
    {
        public SulfurasHand(int sellIn, int quality, string name = "Sulfuras, Hand of Ragnaros")
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public override void UpdateQuality()
        {
            
        }
    }
}