using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using KillMessage.Database;
using NorthwoodLib.Pools;

namespace KillMessage.Commands
{
    public class Delete : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Plugin.Singleton.Config.UsePermissions && sender.CheckPermission("kmsg"))
            {
                response = "No permission.";
                return false;
            }
            
            string msg = "";
            Player.Get(sender).UpdateMessage(msg);
            response = "Kill message deleted";
            return true;
        }

        public string Command { get; } = "deletekmsg";
        public string[] Aliases { get; } = new[] {"delete", "del"};
        public string Description { get; } = "Deletes your kill message";
    }
}