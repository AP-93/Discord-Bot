using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBotCore.Storage
{
    public interface IDataStorage
    {
        void StoreObject(object obj, string key);

        T RestoreObject <T>(string key);
    }
}
