using System;
using System.Linq;
using Exiled.API.Features;
using LiteDB;

namespace KillMessage.Database
{
    public static class Extensions
    {
        private static void AddPlayer(this Player ply, MessageData msg = null)
        {
            try
            {
                if (!Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId))
                    Database.LiteDatabase.GetCollection<MessageData>().Insert(msg);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            
        }

        public static void UpdateMessage(this Player ply, string message = "")
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
                    return;
                }

                var m = Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId);
                m.Message = message;
                
                Database.LiteDatabase.GetCollection<MessageData>().Update(m);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void UpdateDisabled(this Player ply)
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
                        Disabled = true,
                    });
                    return;
                }

                var m = Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId);
                
                m.Disabled = !m.Disabled;
                Database.LiteDatabase.GetCollection<MessageData>().Update(m);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        
        public static void UpdateColor(this Player ply, string color)
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
                    return;
                }

                var m = Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId);
                m.Color = color;
                Database.LiteDatabase.GetCollection<MessageData>().Update(m);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static string GetMessage(this Player ply)
            => !Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId) 
                            ? "" : Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId).Message;
        

        public static bool GetDisabled(this Player ply)
            => Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId)
               && Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId).Disabled;
        

        public static string GetColor(this Player ply)
            => !Database.LiteDatabase.GetCollection<MessageData>().Exists(x => x.UserId == ply.RawUserId) 
                 ? "" : Database.LiteDatabase.GetCollection<MessageData>().FindOne(x => x.UserId == ply.RawUserId).Color;
    }
}