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
    }
}