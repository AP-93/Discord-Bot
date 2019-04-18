using Discord.WebSocket;
using DiscordBotCore.Log;
using DiscordBotCore.Discord;
using DiscordBotCore.Storage;
using DiscordBotCore.Storage.Implementations;
using Unity;
using Unity.Injection;
using DiscordBotCore.Discord.Commands;
using DiscordBotCore.Fortnite;

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
            _container.RegisterSingleton<IConnection, Connection>();
            _container.RegisterSingleton<ICommandHandler, CommandHandler>();
            _container.RegisterSingleton<ILogger,Logger>();
            _container.RegisterSingleton<IHttpClientProvider, HttpClientProvider>();
            _container.RegisterSingleton<ApiWebRequest>();
           // _container.RegisterSingleton<PlayersOnlineInfo>();
            // _container.RegisterType<DiscordSocketConfig>(new InjectionFactory(i => SocketConfigCreator.GetDefault()));
            _container.RegisterFactory<DiscordSocketConfig>(i => SocketConfigCreator.GetDefault());
            _container.RegisterSingleton<DiscordSocketClient>(new InjectionConstructor(typeof(DiscordSocketConfig)));
            _container.RegisterSingleton<Discord.Connection>();
            _container.RegisterSingleton<DiscordBot>();
        }

        public static T Resolve<T>()
        {
            //return (T)Container.Resolve(typeof(T),string.Empty,new CompositeResolverOverride());
            return Container.Resolve<T>();
        }
    }
}
