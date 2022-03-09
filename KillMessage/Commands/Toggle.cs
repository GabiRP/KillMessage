using System;
using CommandSystem;
using Exiled.API.Features;
using KillMessage.Database;

namespace KillMessage.Commands
{
    public class Toggle : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player p = Player.Get(sender);
            
            p.UpdateDisabled();

            response = p.GetDisabled() ? Plugin.Singleton.Translation.MessagesHidden : Plugin.Singleton.Translation.MessagesNotHidden;
            return true;
        }

        public string Command { get; } = "togglekmsg";
        public string[] Aliases { get; } = {"toggle"};
        public string Description { get; } = "Toggles whether or not you can see kill messages";
    }
}