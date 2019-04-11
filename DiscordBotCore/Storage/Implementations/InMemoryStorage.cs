using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBotCore.Storage.Implementations
{
    class InMemoryStorage : IDataStorage
    {
        public InMemoryStorage()
        {
            Console.WriteLine("Inmemory constructor");
        }

        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public T RestoreObject<T>(string key)
        {
            if (!_dictionary.ContainsKey(key))
                throw new ArgumentException($"Povided key '{key}' was not found");

            return (T)_dictionary[key];
        }

        public void StoreObject(object obj, string key)
        {
            if (_dictionary.ContainsKey(key)) return;

            _dictionary.Add(key, obj);
        }
    }
}
