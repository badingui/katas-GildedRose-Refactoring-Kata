using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly ItemFactory _itemFactory = new ItemFactory();

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var gildedRoseItem = _itemFactory.GetItem(item.Name, item.Quality, item.SellIn);

                gildedRoseItem.UpdateQuality();

                item.Quality = gildedRoseItem.Quality;
                item.SellIn = gildedRoseItem.SellIn;
            }
        }
    }
}
