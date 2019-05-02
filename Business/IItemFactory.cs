using GildedRose.Entities;

namespace GildedRose
{
    public interface IItemFactory
    {
        AbstractItem CreateItem(string name, int quality, int sellIn);
    }
}