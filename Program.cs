using System;
using System.Collections.Generic;
using GildedRose.Entities;
using Unity;

namespace GildedRose
{
    public class Program
    {
        private static IItemFactory _itemFactory;

        static Program()
        {
            var container = UnityConfig.Register();
            _itemFactory = container.Resolve<IItemFactory>();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<AbstractItem> Items = new List<AbstractItem>{
                _itemFactory.CreateItem ( name:  "+5 Dexterity Vest", sellIn:  10, quality:  20),
                _itemFactory.CreateItem ( name:  "Aged Brie", sellIn:  2, quality:  0),
                _itemFactory.CreateItem ( name:  "Elixir of the Mongoose", sellIn:  5, quality:  7),
                _itemFactory.CreateItem ( name:  "Sulfuras, Hand of Ragnaros", sellIn:  0, quality:  80),
                _itemFactory.CreateItem ( name:  "Sulfuras, Hand of Ragnaros", sellIn:  -1, quality:  80),
                _itemFactory.CreateItem (
                    name:  "Backstage passes to a TAFKAL80ETC concert",
                    sellIn:  15,
                    quality:  20
                ),
                _itemFactory.CreateItem(
                    name:  "Backstage passes to a TAFKAL80ETC concert",
                    sellIn:  10,
                    quality:  49
                ),
                _itemFactory.CreateItem(
                    name:  "Backstage passes to a TAFKAL80ETC concert",
                    sellIn:  5,
                    quality:  49
                ),
				// this conjured item does not work properly yet
				_itemFactory.CreateItem ( name:  "Conjured Mana Cake", sellIn:  3, quality:  6)
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

            Console.ReadKey();
        }
    }
}
