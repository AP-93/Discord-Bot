using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;


namespace DiscordBotCore
{
    public static class Unity
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get
            {
                if (_container == null)
                    RegisterTypes();
                return _container;
            }
        }

        public static void RegisterTypes()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDataStorage, InMemoryStorage>();
        }

        public static T Resolve<T>()
        {
            //return (T)Container.Resolve(typeof(T),string.Empty,new CompositeResolverOverride());
            return Container.Resolve<T>();
        }
    }
}
