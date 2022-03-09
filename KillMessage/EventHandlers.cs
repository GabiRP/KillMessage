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
                $"<color={ev.Killer.GetColor()}>{ev.Killer.GetMessage()} - <b>{ev.Killer.Nickname}</b></color>");
        }

        internal void OnVerified(VerifiedEventArgs ev)
        {
            if (Plugin.Singleton.Config.SendConsoleMessage)
                ev.Player.SendConsoleMessage("<b>KillMessage</b>\n" +
                                             "A plugin that shows a message to players you kill\n" +
                                             "Usage:\n" +
                                             "· kmsg set - Sets your kill message\n" +
                                             "· kmsg delete - Deletes your kill message\n" +
                                             "· kmsg color - Sets the color for the message\n" +
                                             "· kmsg toggle - Toggles whether or not you can see other's kill messages",
                    "default");
        }
    }
}