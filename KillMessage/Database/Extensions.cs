using System;
using System.Linq;
using Exiled.API.Features;
using LiteDB;

namespace KillMessage.Database
{
    public static class Extensions
    {
        public static bool AddPlayer(this Player ply, MessageData msg = null)
        {
            try
            {
                if (!Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId))
                {
                    Database.LiteDatabase.GetCollection<MessageData>().Insert(msg);
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
            
        }

        public static bool UpdateMessage(this Player ply, string message = "")
        {
            try
            {
                if (!Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId))
                {
                    AddPlayer(ply, new MessageData
                    {
                        Message = message,
                        UserId = ply.RawUserId,
                        Color = "yellow",
                        Disabled = false,
                    });
                    return true;
                }

                var m = Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId);
                m.Message = message;
                
                Database.LiteDatabase.GetCollection<MessageData>().Update(m);

                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        public static bool UpdateDisabled(this Player ply)
        {
            try
            {
                if (!Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId))
                {
                    AddPlayer(ply, new MessageData
                    {
                        Message = "",
                        UserId = ply.RawUserId,
                        Color = "yellow",
                        Disabled = false,
                    });
                    return true;
                }

                var m = Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId);
                
                m.Disabled = !m.Disabled;
                Database.LiteDatabase.GetCollection<MessageData>().Update(m);

                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        
        public static bool UpdateColor(this Player ply, string color)
        {
            try
            {
                if (!Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId))
                {
                    AddPlayer(ply, new MessageData
                    {
                        Message = "",
                        UserId = ply.RawUserId,
                        Color = color,
                        Disabled = false,
                    });
                    return true;
                }

                var m = Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId);
                if (m != null)
                {
                    m.Color = "yellow";
                    Database.LiteDatabase.GetCollection<MessageData>().Update(m);
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        
        public static string GetMessage(this Player ply)
         => Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId).Message ?? "";

        public static bool GetDisabled(this Player ply)
        {
            if(!Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId))
                return false;
            return Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId).Disabled;
        }

        public static string GetColor(this Player ply)
            => Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId).Color
                .ToString();
    }
}