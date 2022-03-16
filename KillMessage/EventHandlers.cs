﻿using Exiled.Events.EventArgs;
using KillMessage.Database;

namespace KillMessage
{
    public class EventHandlers
    {
        internal void OnDied(DiedEventArgs ev)
        {
            if(ev.Target.GetDisabled() || ev.Killer == null || ev.Target == null || string.IsNullOrEmpty(ev.Killer.GetMessage())) return;
            
            ev.Target.ShowHint(
                $"<size={Plugin.Singleton.Config.MessageSize}><color={ev.Killer.GetColor()}>{Plugin.Singleton.Translation.Message.Replace("$message", ev.Killer.GetMessage()).Replace("$author", ev.Killer.Nickname)}</color></size>", Plugin.Singleton.Config.MessageDuration);

        }

        internal void OnVerified(VerifiedEventArgs ev)
        {
            if (Plugin.Singleton.Config.SendConsoleMessage)
                ev.Player.SendConsoleMessage(Plugin.Singleton.Translation.ConsoleMessage.Replace("$helpmsg", Plugin.Singleton.Translation.HelpMessage),
                    "default");
        }
    }
}