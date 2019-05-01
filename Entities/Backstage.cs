namespace csharp.Entities
{
    public class Backstage : Item
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
                Quality = Quality + 1;

                if (SellIn < 11)
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }

                if (SellIn < 6)
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality - Quality;
            }

        }
    }
}