using System;
using CommandSystem;
using Exiled.API.Features;
using KillMessage.Database;

namespace KillMessage.Commands
{
    public class Disable : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player p = Player.Get(sender);
            string msg = "";
            p.UpdateDisabled();
            if (p.GetDisabled())
            {
                response = "Kill messages are now hidden";
                return true;
            }

            response = "Kill messages are no longer hidden";
            return true;
        }

        public string Command { get; } = "togglekmsg";
        public string[] Aliases { get; } = {"toggle"};
        public string Description { get; } = "Toggles whether or not you can see kill messages";
    }
}