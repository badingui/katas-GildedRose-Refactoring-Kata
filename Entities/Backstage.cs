namespace GildedRose.Entities
{
    public class Backstage : AbstractItem
    {
        public Backstage(int sellIn, int quality, string name = "Backstage passes to a TAFKAL80ETC concert")
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;

                if (SellIn < 11)
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }
                }

                if (SellIn < 6)
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }
                }
            }

            DecrementSellIn();

            if (SellIn < 0)
            {
                Quality -= Quality;
            }

        }
    }
}