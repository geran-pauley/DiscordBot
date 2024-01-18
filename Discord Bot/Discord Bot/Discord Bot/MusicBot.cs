using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord_Bot
{
    public class MusicBot
    {
        private DiscordSocketClient _client;
        private CommandService _cmdService;

        public MusicBot(DiscordSocketClient client = null, CommandService cmdService = null)
        {
            _client = client ?? new DiscordSocketClient(new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                MessageCacheSize = 50,
                LogLevel = Discord.LogSeverity.Debug
            });

            _cmdService = cmdService ?? new CommandService(new CommandServiceConfig
            {
                LogLevel = Discord.LogSeverity.Verbose,
                CaseSensitiveCommands = true,
                
            });
        }
    }
}
