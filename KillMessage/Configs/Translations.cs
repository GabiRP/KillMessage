using System.ComponentModel;
using Exiled.API.Interfaces;

namespace KillMessage.Configs
{
    public class Translations : ITranslation
    {
        [Description("Console message sent to players when they join. %helpmsg will be replaced with the help message")]
        public string ConsoleMessage { get; set; } = "\n<b>KillMessage</b>\n" +
                                                     "A plugin that shows a message to players you kill\n$helpmsg";

        [Description("Help message")]
        public string HelpMessage { get; set; } = "\nUsage:\n" +
                                                  "· kmsg set - Sets your kill message\n" +
                                                  "· kmsg delete - Deletes your kill message\n" +
                                                  "· kmsg toggle - Toggles whether or not you can see kill messages\n" +
                                                  "· kmsg color - Sets your kill message color";
        
        [Description("Message sent to players without permissions to use the command")]
        public string NoPerms { get; set; } = "No permission.";

        [Description("Delete command response")]
        public string DeleteCmd { get; set; } = "Kill message deleted.";

        [Description("Max characters error. $limit will be replaced with character limit")]
        public string MaxChars { get; set; } = "You can only enter up to $limit characters";

        [Description("Empty message error response")]
        public string EmptyMessage { get; set; } =
            "You can't set an empty message, if you want to delete your message, use kmsg delete";

        [Description("Set command response")] 
        public string SetCmd { get; set; } = "Kill message set";

        [Description("Color not found error. $color will be replaced with the color")]
        public string ColorNotFound { get; set; } = "Could not find color $color";

        [Description("Color command response")]
        public string ColorCmd { get; set; } = "Color updated";

        [Description("Color empty error reponse")]
        public string ColorEmpty { get; set; } =
            "The color you're setting can't be empty, if you want to set your color to white, use default or white";

        [Description("Messages hidden response")]
        public string MessagesHidden { get; set; } = "Kill messages are now hidden";
        [Description("Messages no longer hidden response")]
        public string MessagesNotHidden { get; set; } = "Kill messages are no longer hidden";

    }
}