using System;
using System.IO;
using LiteDB;

namespace KillMessage.Database
{
    public class Database
    {
        public static LiteDatabase LiteDatabase { get; set; }
        public static string Folder = Plugin.Singleton.Config.DatabaseFolder;
        public static string FilePath = Path.Combine(Folder, "KillMessage.db");
        public static void Open()
        {
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);
            LiteDatabase = new LiteDatabase(new ConnectionString(FilePath)
            {
                Connection = ConnectionType.Shared
            });

            LiteDatabase.GetCollection<MessageData>().EnsureIndex(x => x.UserId, true);
            LiteDatabase.GetCollection<MessageData>().EnsureIndex(x => x.Message);
            LiteDatabase.GetCollection<MessageData>().EnsureIndex(x => x.Disabled);
            LiteDatabase.GetCollection<MessageData>().EnsureIndex(x => x.Color);
        }

        public static void Close()
        {
            LiteDatabase.Checkpoint();
            LiteDatabase.Dispose();
            LiteDatabase = null;
        }
    }
}