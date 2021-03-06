﻿using System.Collections.Generic;
using GildedRose.Entities;
using NUnit.Framework;
using Unity;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        //Une fois que la date de péremption est passée, la qualité se dégrade deux fois plus rapidement.
        //La qualité (quality) d'un produit ne peut jamais être négative.
        //"Aged Brie" augmente sa qualité (quality) plus le temps passe.
        //La qualité d'un produit n'est jamais de plus de 50.
        //"Sulfuras", étant un objet légendaire, n'a pas de date de péremption et ne perd jamais en qualité (quality)
        //"Backstage passes", comme le "Aged Brie", augmente sa qualité (quality) plus le temps passe (sellIn) ; La qualité augmente de 2 quand il reste 10 jours ou moins et de 3 quand il reste 5 jours ou moins, mais la qualité tombe à 0 après le concert.

        //	- "Conjured" items degrade in Quality twice as fast as normal items
        public IItemFactory ItemFactory { get; set; }

        public GildedRoseTest()
        {
            var container = UnityConfig.Register();
            ItemFactory = container.Resolve<IItemFactory>();
        } 

        [Test]
        public void When_ItemIs_Conjured_Quality_DegradesTwice()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Conjured Mana Cake", sellIn: 1, quality: 10 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].Quality);
        }

        [Test]
        public void When_SellDatePassed_Quality_DegradesTwice()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Test Prod", sellIn: 1, quality: 10 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(7, Items[0].Quality);
        }

        [Test]
        public void QualityValue_IsNever_Negative()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Test Prod", sellIn: 0, quality: 0 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            for (var i = 0; i < 10; i++)
            {
                app.UpdateQuality();
                Assert.IsTrue(Items[0].Quality >= 0);
            }
        }

        [Test]
        public void QualityValue_IsNever_MoreThan_50()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Aged Brie", sellIn: 0, quality: 50 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);
            var initialQuality = Items[0].Quality;

            for (var i = 0; i < 50; i++)
            {
                app.UpdateQuality();
            }

            Assert.IsTrue(initialQuality <= 50 && Items[0].Quality <= 50);
        }

        [Test]
        public void When_ItemIs_Sulfuras_Quality_NotChanged()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 11 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            for (var i = 0; i < 50; i++)
            {
                app.UpdateQuality();
            }

            Assert.IsTrue(Items[0].Quality == 11);
        }

        [Test]
        public void When_ItemIs_Sulfuras_SellIn_NotChanged()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 11 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            for (var i = 0; i < 50; i++)
            {
                app.UpdateQuality();
            }

            Assert.IsTrue(Items[0].SellIn == 1);
        }

        [Test]
        public void When_ItemIs_AgedBrie_And_GetOlder_Quality_Increases()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Aged Brie", sellIn: 0, quality: 0 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            for (var i = 0; i < 10; i++)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(20, Items[0].Quality);
        }

        [Test]
        public void When_ItemIs_Backstage_And_GetOlderLessThan_5_Days_Quality_Increases_By_3()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5, quality: 0 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            for (var i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(15, Items[0].Quality);
        }

        [Test]
        public void When_ItemIs_Backstage_And_GetOlderLessThan_10_Days_Quality_Increases_By_2()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 10, quality: 0 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            for (var i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(10, Items[0].Quality);
        }

        [Test]
        public void When_ItemIs_Backstage_And_GetOlderMoreThan_10_Days_Quality_DropTo_0()
        {
            IList<AbstractItem> Items = new List<AbstractItem> { ItemFactory.CreateItem( name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0, quality: 10 ) };;
            global::GildedRose.GildedRose app = new global::GildedRose.GildedRose(Items);

            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
