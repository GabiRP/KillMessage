using System.ComponentModel;
using System.IO;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace KillMessage
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("The folder where the database file will be stored in")]
        public string DatabaseFolder { get; set; } = Path.Combine(Paths.Plugins, "KillMessage");

        [Description("Whether or not use permissions to be able to use the command (permission: kmsg)")]
        public bool UsePermissions { get; set; } = false;

        [Description("Whether or not to send a message to a player that joins to tell them about the plugin")]
        public bool SendConsoleMessage { get; set; } = true;

        [Description("Kill message's character limit")]
        public int CharLimit { get; set; } = 32;

        [Description("Message size")]
        public int MessageSize { get; set; } = 30;

        [Description("Message duration")] 
        public ushort MessageDuration { get; set; } = 3;
        
        [Description("List of available colors. MAKE SURE TO WRITE THEM IN LOWER CASE AND USE SCPSL WIKI COLORS")]
        public string[] AvailableColors { get; set; } = new[]
        {
            "pink", "red", "brown", "silver", "light_green", "crimson", "cyan", "aqua", "deep_pink", "tomato", "yellow", "magenta", "blue_green",
            "orange"
        };
    }
}