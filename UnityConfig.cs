using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GildedRose
{
    public class UnityConfig
    {
        public static IUnityContainer Register()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IItemFactory, ItemFactory>();

            return container;
        }
    }
}
