using System;
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
                response = "No permission.";
                return false;
            }
            
            Player p = Player.Get(sender);
            
            string msg = "";
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            foreach (string argument in arguments)
            {
                stringBuilder.Append(argument);
                stringBuilder.Append(" ");
            }
            msg = stringBuilder.ToString();
            StringBuilderPool.Shared.Return(stringBuilder);
            if (msg.Length > Plugin.Singleton.Config.CharLimit)
            {
                response = $"You can only enter up to {Plugin.Singleton.Config.CharLimit} characters";
                return false;
            }
            p.UpdateMessage(msg);
            response = "Kill message updated";
            return true;
        }

        public string Command { get; } = "setkmsg";
        public string[] Aliases { get; } = new[] {"set"};
        public string Description { get; } = "Sets your kill message";
    }
}