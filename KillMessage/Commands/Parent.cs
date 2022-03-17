using System;
using System.Runtime.InteropServices;
using CommandSystem;
using CommandSystem.Commands.RemoteAdmin.PermissionsManagement.Group;
using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using KillMessage.Database;
using Mirror;

namespace KillMessage.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Parent : ParentCommand
    {
        public Parent() => LoadGeneratedCommands();
        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new Set());
            RegisterCommand(new Delete());
            RegisterCommand(new Toggle());
            RegisterCommand(new SetColor());
        }
        
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Plugin.Singleton.Config.UsePermissions && !sender.CheckPermission("kmsg"))
            {
                response = Plugin.Singleton.Translation.NoPerms;
                return false;
            }

            string current = Player.Get(sender).GetMessage();
            response = Plugin.Singleton.Translation.HelpMessage.Replace($"$current", string.IsNullOrEmpty(current) ? Plugin.Singleton.Translation.MessageNotSet : current);
            return true;
        }

        public override string Command { get; } = "killmessage";
        public override string[] Aliases { get; } = {"kmsg"};
        public override string Description { get; } = "Sets or deletes your kill message. Available commands: kmsg set, kmsg delete, kmsg toggle, kmsg color";
        
    }
}