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
            if (sender.CheckPermission("kmsg"))
            {
                response = Plugin.Singleton.Translation.NoPerms;
                return false;
            }
            
            Player.Get(sender).UpdateMessage();
            response = Plugin.Singleton.Translation.DeleteCmd;
            return true;
        }

        public string Command { get; } = "deletekmsg";
        public string[] Aliases { get; } = new[] {"delete", "del"};
        public string Description { get; } = "Deletes your kill message";
    }
}