using csharp.Entities;

namespace csharp
{
    public class ItemFactory
    {
        public Item GetItem(string name, int quality, int sellIn)
        {
            switch (name)
            {
                case "Aged Brie":
                    return new AgedBrie(sellIn, quality, name);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new Backstage(sellIn, quality, name);
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasHand(sellIn, quality, name);
                case "Conjured":
                    return new Conjured(sellIn, quality, name);
                default:
                    return new Item()
                    {
                        Name = name,
                        SellIn = sellIn,
                        Quality = quality
                    };

            }
        }
    }
}
