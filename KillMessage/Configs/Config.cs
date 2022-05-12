using System.ComponentModel;
using System.IO;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace KillMessage.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("The folder where the database file will be stored in")]
        public string DatabaseFolder { get; set; } = Path.Combine(Paths.Plugins, "KillMessage");

        [Description("Whether or not to send a message to a player that joins to tell them about the plugin")]
        public bool SendConsoleMessage { get; set; } = true;

        [Description("Kill message's character limit")]
        public int CharLimit { get; set; } = 32;

        [Description("A list of blacklisted words")]
        public string[] BlacklistedWords { get; set; } = {"your", "blacklisted", "words", "go", "here"};

        [Description("Size of the message that's shown to the killed player")]
        public int MessageSize { get; set; } = 30;

        [Description("Duration of the message that's shown to the killed player")] 
        public ushort MessageDuration { get; set; } = 3;

        [Description("If broadcasts should be used instead of hints")]
        public bool UseBroadcast { get; set; } = false;
        
        [Description("List of available colors. MAKE SURE TO USE SCPSL WIKI COLORS")]
        public string[] AvailableColors { get; set; } = {
            "pink", "red", "brown", "silver", "light_green", "crimson", "cyan", "aqua", "deep_pink", "tomato", "yellow", "magenta", "blue_green",
            "orange"
        };

        [Description("Whether or not to send the message if the player suicides")]
        public bool ShowOnSuicide { get; set; } = true;
    }
}