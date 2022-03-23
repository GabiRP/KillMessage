using System;
using System.Linq;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using KillMessage.Database;
using NorthwoodLib.Pools;

namespace KillMessage.Commands
{
    public class Set : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Plugin.Singleton.Config.UsePermissions && sender.CheckPermission("kmsg"))
            {
                response = Plugin.Singleton.Translation.NoPerms;
                return false;
            }
            
            Player p = Player.Get(sender);
            
            string msg = "";
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            foreach (string argument in arguments)
            {
                stringBuilder.Append(argument);
                if (Plugin.Singleton.Config.BlacklistedWords.Contains(argument))
                {
                    response = "There are blacklisted words in your message";
                    return false;
                }
                stringBuilder.Append(" ");
            }
            msg = stringBuilder.ToString();
            StringBuilderPool.Shared.Return(stringBuilder);
            if (string.IsNullOrEmpty(msg))
            {
                response = Plugin.Singleton.Translation.EmptyMessage;
                return false;
            }
            if (msg.Length > Plugin.Singleton.Config.CharLimit)
            {
                response = Plugin.Singleton.Translation.MaxChars.Replace("$limit", Plugin.Singleton.Config.CharLimit.ToString());
                return false;
            }
            
            p.UpdateMessage(msg);
            response = Plugin.Singleton.Translation.SetCmd;
            return true;
        }

        public string Command { get; } = "setkmsg";
        public string[] Aliases { get; } = new[] {"set"};
        public string Description { get; } = "Sets your kill message";
    }
}