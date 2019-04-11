using DiscordBotCore.Storage;
using System;

namespace DiscordBotCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Unity.RegisterTypes();

            var mp = Unity.Resolve<MyProfile>();

            Console.WriteLine("Hello World!");

     
        }
    }

    public class MyProfile
    {
        private readonly IDataStorage _storage;

        public MyProfile (IDataStorage storage)
        {
            _storage = storage;
        }
        public void NewUser (string name)
        {
            var registrationTime = DateTime.UtcNow;

            _storage.StoreObject(registrationTime, name);
        }

    }
}
