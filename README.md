# KillMessage

An Exiled 5 plugin that shows a message to players you kill.

[![Github All Releases](https://img.shields.io/github/downloads/GabiRP/KillMessage/total?color=blue&style=for-the-badge)]()

## Available Commands

- kmsg set - Sets your kill message
- kmsg delete - Deletes your kill message
- kmsg toggle - Toggles whether or not you can see kill messages
- kmsg color - Sets your kill message color

## Configs

| Config               | Type     | Description                                                                                                  | Default                                                                                                            |
|----------------------|----------|--------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------|
| is_enabled           | bool     | Whether the plugin is enabled                                                                                | true                                                                                                               |
| database_folder      | string   | The folder where the database will be stored in                                                              | PLUGINS_FOLDER/KillMessage                                                                                         |
| use_permissions      | bool     | Whether or not use permissions to be able to use commands. Permission: kmsg                                  | false                                                                                                              |
| send_console_message | bool     | Whether or not send a message through the client console to a player who joins to tell them about the plugin | true                                                                                                               |
| char_limit           | int      | Message's character limit                                                                                    | 32                                                                                                                 |
| message_size         | int      | Size of the message that's shown to the killed player                                                        | 30                                                                                                                 |
| message_duration     | ushort   | Duration of the message that's shown to the killed player                                                    |                                                                                                                    |
| available_colors     | string[] | List of available colors. MAKE SURE TO WRITE THEM IN LOWER CASE AND USE SCPSL WIKI COLORS                    | pink, red, brown, silver, light_green, crimson, cyan, aqua, deep_pink, tomato, yellow, magenta, blue_green, orange |
