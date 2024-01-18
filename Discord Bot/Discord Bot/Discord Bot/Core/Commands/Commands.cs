using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Victoria;

namespace Discord_Bot.Core.Commands
{

    public class Commands : ModuleBase<SocketCommandContext>
    {

        [Command("!"), Alias("Druid", "Hunter", "Mage", "Priest", "Rogue", "Shaman", "Warlock", "Warrior")]
        public async Task AssignRole()
        {
            var user = Context.User;
            string classCommand = Context.Message.Content;
            char[] commandRemove = { '!' };
            string Spec = classCommand.TrimStart(commandRemove);
            var channel = Context.Guild;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == Spec);

            if (Context.Channel.Id != 583842128036102154)
            {
                await Context.Channel.SendMessageAsync(Context.Message.Author.Mention + " please refer to the " + "<#583842128036102154>" + " channel to receive a rank");
                Console.WriteLine("Wrong Channel");

            }
            if (Context.Message.Channel.Id == 583842128036102154)
            {
                await (user as IGuildUser).AddRoleAsync(role);
                await Context.Channel.SendMessageAsync(Context.Message.Author.Mention + " has chosen " + role + " as their class!");
                Console.WriteLine("Right Channel");
            }

        }
        [Command("!"), Alias("Commands")]
        public async Task CommandList()
        {
            await Context.Channel.SendMessageAsync("!Floof \n!Wand \n!Kicked \n!Gnomer \n!Brandon \n!Torch \n!Shout \n!Grinch \n!shout except its furry");

        }

        [Command("ello there")]
        public async Task Memes()
        {
            Console.WriteLine("TEST");
            await Context.Channel.SendMessageAsync("https://i.imgur.com/Oyx0TPo.gif");
        }

        [Command("!"), Alias("Floof")]
        public async Task Floof()
        {
            await Context.Channel.SendFileAsync("C:\\Discord Bot-Master\\Discord Bot\\FloofReroll.png");
        }
        [Command("!"), Alias("Wand")]
        public async Task Wand()
        {
            await Context.Channel.SendFileAsync("C:\\Discord Bot-Master\\Discord Bot\\Wand.png");
        }

        [Command("!"), Alias("Frank")]
        public async Task Frank()
        {
            await Context.Channel.SendMessageAsync("https://www.twitch.tv/atsou/clip/NeighborlyEnchantingEyeballPraiseIt?filter=clips&range=all&sort=time");
        }

        [Command("!"), Alias("Kicked")]
        public async Task Kicked()
        {
            await Context.Channel.SendFileAsync("C:\\Discord Bot-Master\\Discord Bot\\kicked.png");
        }

        [Command("!"), Alias("Gnomer")]
        public async Task Gnomer()
        {
            await Context.Channel.SendFileAsync("C:\\Discord Bot-Master\\Discord Bot\\Gnomer.jpg");
        }

        [Command("!"), Alias("Brandon")]
        public async Task Brandon()
        {
            await Context.Channel.SendFileAsync("C:\\Discord Bot-Master\\Discord Bot\\Brandon.png");
        }

        [Command("!"), Alias("Torch")]
        public async Task Torch()
        {
            await Context.Channel.SendMessageAsync("https://clips.twitch.tv/AgitatedFaintAlpacaNinjaGrumpy");
        }

        [Command("!"), Alias("Shout")]
        public async Task Shout()
        {
            await Context.Channel.SendMessageAsync("https://i.imgur.com/P9SV187.mp4");
        }

        [Command("!"), Alias("Grinch")]
        public async Task Grinch()
        {
            await Context.Channel.SendMessageAsync("https://i.imgur.com/NCxgsYG.gif");
        }

        [Command("!"), Alias("Trevor")]
        public async Task Trevor()
        {
            Random rnd = new Random();
            int filechoice = rnd.Next(1, 8);
            if (filechoice == 1)
            {
                await Context.Channel.SendFileAsync("C:\\Users\\Geran Pauley\\Desktop\\Reactions for when my brother posts weird shit\\1.mp4");
            }
            if (filechoice == 2)
            {
                await Context.Channel.SendFileAsync("C:\\Users\\Geran Pauley\\Desktop\\Reactions for when my brother posts weird shit\\2.jpg");
            }
            if (filechoice == 3)
            {
                await Context.Channel.SendFileAsync("C:\\Users\\Geran Pauley\\Desktop\\Reactions for when my brother posts weird shit\\3.gif");
            }
            if (filechoice == 4)
            {
                await Context.Channel.SendFileAsync("C:\\Users\\Geran Pauley\\Desktop\\Reactions for when my brother posts weird shit\\4.png");
            }
            if (filechoice == 5)
            {
                await Context.Channel.SendFileAsync("C:\\Users\\Geran Pauley\\Desktop\\Reactions for when my brother posts weird shit\\5.gif");
            }
            if (filechoice == 6)
            {
                await Context.Channel.SendFileAsync("C:\\Users\\Geran Pauley\\Desktop\\Reactions for when my brother posts weird shit\\6.gif");
            }
            if (filechoice == 7)
            {
                await Context.Channel.SendMessageAsync("https://www.youtube.com/watch?v=DzDztyS09CU");
            }


        }
    }
};
