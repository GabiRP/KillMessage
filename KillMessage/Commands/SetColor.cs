using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using KillMessage.Database;
using KillMessage.Enums;

namespace KillMessage.Commands
{
    public class SetColor : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Plugin.Singleton.Config.UsePermissions && sender.CheckPermission("kmsg"))
            {
                response = "No permission.";
                return false;
            }
            
            Player p = Player.Get(sender);
            
            if (!Enum.TryParse(arguments.ElementAt(0), out Color c))
            {
                response = $"Could not find the color {arguments.ElementAt(0)}";
                return false;
            }
            p.UpdateColor(c);

            response = "Color updated";
            return true;
        }

        public string Command { get; } = "color";
        public string[] Aliases { get; } = {"setcolorkmsg", "setcolor"};
        public string Description { get; } = "Sets your kill message color";
    }
}