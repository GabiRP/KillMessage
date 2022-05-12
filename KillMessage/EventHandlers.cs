using Exiled.Events.EventArgs;
using KillMessage.Database;

namespace KillMessage
{
    public class EventHandlers
    {
        internal void OnDied(DiedEventArgs ev)
        {
            if(ev.Target.GetDisabled() || ev.Killer == null || ev.Target == null || string.IsNullOrEmpty(ev.Killer.GetMessage()) || (!Plugin.Singleton.Config.ShowOnSuicide && ev.Target == ev.Killer)) return;
            
            string message = $"<size={Plugin.Singleton.Config.MessageSize}><color={ev.Killer.GetColor()}>{Plugin.Singleton.Translation.Message.Replace("$message", ev.Killer.GetMessage()).Replace("$author", ev.Killer.Nickname)}</color></size>";

            if (Plugin.Singleton.Config.UseBroadcast)
            {
                ev.Target.Broadcast(Plugin.Singleton.Config.MessageDuration, message);
                return;
            }
            
            ev.Target.ShowHint(message, Plugin.Singleton.Config.MessageDuration);
        }

        internal void OnVerified(VerifiedEventArgs ev)
        {
            if (Plugin.Singleton.Config.SendConsoleMessage)
            {
                string current = ev.Player.GetMessage();
                string color = ev.Player.GetColor();
                ev.Player.SendConsoleMessage(Plugin.Singleton.Translation.ConsoleMessage.Replace("$helpmsg", Plugin.Singleton.Translation.HelpMessage).Replace("$current", string.IsNullOrEmpty(current) ? Plugin.Singleton.Translation.MessageNotSet : current).Replace("$color", color),
                    "default");
            }
        }
    }
}