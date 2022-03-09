using System;
using Exiled.API.Features;

namespace KillMessage
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "KillMessage";
        public override string Author => "GabiRP";
        public override Version Version { get; } = new Version(0, 0, 1,1);
        public override Version RequiredExiledVersion { get; } = new Version(4, 2, 5);

        public static Plugin Singleton;
        public EventHandlers EventHandlers;
        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers();
            Database.Database.Open();
            Exiled.Events.Handlers.Player.Died += EventHandlers.Died;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Database.Database.Close();
            Exiled.Events.Handlers.Player.Died -= EventHandlers.Died;
            base.OnDisabled();
        }
    }
}