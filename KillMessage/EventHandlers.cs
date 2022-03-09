using Exiled.Events.EventArgs;
using KillMessage.Database;

namespace KillMessage
{
    public class EventHandlers
    {
        internal void OnDied(DiedEventArgs ev)
        {
            if(ev.Target.GetDisabled() || ev.Killer == null || ev.Target == null || string.IsNullOrEmpty(ev.Killer.GetMessage())) return;
            ev.Target.ShowHint(
                $"<size={Plugin.Singleton.Config.MessageSize}><color={ev.Killer.GetColor()}>{ev.Killer.GetMessage()} - <b>{ev.Killer.Nickname}</b></color></size>", Plugin.Singleton.Config.MessageDuration);

        }

        internal void OnVerified(VerifiedEventArgs ev)
        {
            if (Plugin.Singleton.Config.SendConsoleMessage)
                ev.Player.SendConsoleMessage(Plugin.Singleton.Translation.ConsoleMessage.Replace("$helpmsg", Plugin.Singleton.Translation.HelpMessage),
                    "default");
        }
    }
}