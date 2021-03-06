﻿namespace GildedRose.Entities
{
    public class AgedBrie : AbstractItem
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
                Quality += 1;
            }

            DecrementSellIn();

            if (SellIn < 0 && Quality < 50)
            {
                Quality += 1;
            }
        }
    }
}