using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord_Bot.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Victoria;

namespace Discord_Bot.Core.Commands
{
    public class Music : ModuleBase<SocketCommandContext>
    {
        private MusicService _musicService;

        public Music(MusicService musicService)
        {
            _musicService = musicService;
        }


        [Command("Join")]
        public async Task Join()
        {
            var user = Context.User as SocketGuildUser;
            Console.WriteLine(user.VoiceChannel);
            if (user.VoiceChannel is null)
            {
                await ReplyAsync("You must join a voice channel");
                return;
            }

            else
            {
                await _musicService.ConnectAsync(user.VoiceChannel, Context.Channel as ITextChannel);
                await ReplyAsync($"now connected to {user.VoiceChannel.Name}");
            }
        }
    }
}
