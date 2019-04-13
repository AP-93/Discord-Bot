using Discord.WebSocket;
using DiscordBotCore.Discord;
using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

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
            _container.RegisterSingleton<IDataStorage, JsonStorage>();
            _container.RegisterSingleton<ILogger,Logger>();

            _container.RegisterType<DiscordSocketConfig>(new InjectionFactory(i => SocketConfigCreator.GetDefault()));
            //_container.RegisterFactory<DiscordSocketConfig>(i => SocketConfigCreator.GetDefault());

            _container.RegisterSingleton<DiscordSocketClient>(new InjectionConstructor(typeof(DiscordSocketConfig)));
            _container.RegisterSingleton<Discord.Connection>();
            
        }

        public static T Resolve<T>()
        {
            //return (T)Container.Resolve(typeof(T),string.Empty,new CompositeResolverOverride());
            return Container.Resolve<T>();
        }
    }
}
