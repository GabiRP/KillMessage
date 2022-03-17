using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using KillMessage.Database;

namespace KillMessage.Commands
{
    public class SetColor : ICommand
    {
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Plugin.Singleton.Config.UsePermissions && sender.CheckPermission("kmsg"))
            {
                response = Plugin.Singleton.Translation.NoPerms;
                return false;
            }
            
            Player p = Player.Get(sender);
            if (arguments.Count < 1)
            {
                response = Plugin.Singleton.Translation.ColorEmpty;
                return false;
            }
            string c = arguments.ElementAt(0);
            if (string.IsNullOrEmpty(c))
            {
                response = Plugin.Singleton.Translation.ColorEmpty;
                return false;
            }
            if (!Plugin.Singleton.Config.AvailableColors.Contains(c, StringComparison.OrdinalIgnoreCase))
            {
                response = Plugin.Singleton.Translation.ColorNotFound.Replace("$color", arguments.ElementAt(0));
                return false;
            }
            p.UpdateColor(c);

            response = Plugin.Singleton.Translation.ColorCmd;
            return true;
        }

        public string Command { get; } = "color";
        public string[] Aliases { get; } = {"setcolorkmsg", "setcolor"};
        public string Description { get; } = "Sets your kill message color";
    }
}