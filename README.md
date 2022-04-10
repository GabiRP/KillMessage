# KillMessage

An Exiled plugin that shows a message to players you kill.

IT SHOULD BE SAFE TO USE THE SAME DATABASE IN MULTIPLE SERVERS AT ONCE

[![Github All Releases](https://img.shields.io/github/downloads/GabiRP/KillMessage/total?color=blue&style=for-the-badge)]()

## Available Commands

- kmsg set - Sets your kill message
- kmsg delete - Deletes your kill message
- kmsg toggle - Toggles whether or not you can see kill messages
- kmsg color - Sets your kill message color

## Configs

|        Config        |   Type   |                                                  Description                                                 |                                                       Default                                                      |
|:--------------------:|:--------:|:------------------------------------------------------------------------------------------------------------:|:------------------------------------------------------------------------------------------------------------------:|
|      is_enabled      |   bool   |                                         Whether the plugin is enabled                                        |                                                        true                                                        |
|    database_folder   |  string  |                                The folder where the database will be stored in                               |                                             PLUGINS_FOLDER/KillMessage                                             |
|    use_permissions   |   bool   |                  Whether or not use permissions to be able to use commands. Permission: kmsg                 |                                                        false                                                       |
| send_console_message |   bool   | Whether or not send a message through the client console to a player who joins to tell them about the plugin |                                                        true                                                        |
|      char_limit      |    int   |                                           Message's character limit                                          |                                                         32                                                         |
|     message_size     |    int   |                             Size of the message that's shown to the killed player                            |                                                         30                                                         |
|   message_duration   |  ushort  |                           Duration of the message that's shown to the killed player                          |                                                          3                                                         |
|   available_colors   | string[] |           List of available colors. MAKE SURE TO WRITE THEM IN LOWER CASE AND USE SCPSL WIKI COLORS          | pink, red, brown, silver, light_green, crimson, cyan, aqua, deep_pink, tomato, yellow, magenta, blue_green, orange |


## Permissions

| **Permission** |                    **Description**                   |
|:--------------:|:----------------------------------------------------:|
|     _kmsg_     | Permission to run all commands (except 'kmsg color') |
|  _kmsg.color_  |            Permission to run 'kmsg color'            |

### Give permission to all users

- If you want to give all users a permission, there should be a group in your ``permissions.yml`` file called 'user' with ``default`` set to ``true``, simply add the permission you want to give to everyone there.

## Colors

For broadcast, you'll need to use colors from [Unity Rich Text](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/StyledText.html)
For hints, only ``red, yellow, orange, black, blue, green, grey, lightblue, purple`` work.
