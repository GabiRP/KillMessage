using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using KillMessage.Database;

namespace KillMessage
{
    public class EventHandlers
    {
        internal void OnDied(DiedEventArgs ev)
        {
            if(ev.Player.GetDisabled() || ev.Attacker is null || ev.Player is null 
               || string.IsNullOrEmpty(ev.Attacker.GetMessage()) 
               || (!Plugin.Singleton.Config.ShowOnSuicide && ev.Player == ev.Attacker)) return;
            
            string message = $"<size={Plugin.Singleton.Config.MessageSize}><color={ev.Attacker.GetColor()}>{Plugin.Singleton.Translation.Message.Replace("$message", ev.Attacker.GetMessage()).Replace("$author", ev.Attacker.Nickname)}</color></size>";

            if (Plugin.Singleton.Config.UseBroadcast)
            {
                ev.Player.Broadcast(Plugin.Singleton.Config.MessageDuration, message);
                return;
            }
            
            ev.Player.ShowHint(message, Plugin.Singleton.Config.MessageDuration);
        }

        internal void OnVerified(VerifiedEventArgs ev)
        {
            if (Plugin.Singleton.Config.SendConsoleMessage)
            {
                string current = ev.Player.GetMessage();
                string color = ev.Player.GetColor();
                ev.Player.SendConsoleMessage(Plugin.Singleton.Translation.ConsoleMessage
                        .Replace("$helpmsg", Plugin.Singleton.Translation.HelpMessage)
                        .Replace("$current", string.IsNullOrEmpty(current) ? Plugin.Singleton.Translation.MessageNotSet 
                            : current)
                        .Replace("$color", color),
                    "default");
            }
        }
    }
}