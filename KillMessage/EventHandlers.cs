using Exiled.Events.EventArgs;
using KillMessage.Database;

namespace KillMessage
{
    public class EventHandlers
    {
        internal void Died(DiedEventArgs ev)
        {
            if(ev.Target.GetDisabled() || ev.Killer == null || ev.Target == null || string.IsNullOrEmpty(ev.Killer.GetMessage())) return;
            ev.Target.ShowHint(
                $"<color={ev.Killer.GetColor()}>{ev.Killer.GetMessage()} - <b>{ev.Killer.Nickname}</b></color>");
        }
    }
}