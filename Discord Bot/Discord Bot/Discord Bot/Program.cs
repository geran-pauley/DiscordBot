using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord_Bot.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Victoria;

namespace DiscordBot
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;
        private IServiceProvider Services;
        static void Main(string[] args)
        => new Program()
            .MainAsync()
            .GetAwaiter()
            .GetResult();

        private async Task MainAsync()/*Start Async*/
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug,
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = false,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });
            Services = SetupService();
            Client.MessageReceived += Client_MessageReceived;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
            Client.Ready += Client_Ready;

            Client.Log += Client_Log;
            string Token = "";
            using (var Stream = new FileStream((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).Replace(@"bin\Debug\netcoreapp2.1", @"Data\Token.txt"), FileMode.Open, FileAccess.Read))
            using (var ReadToken = new StreamReader(Stream))
            {
                Token = ReadToken.ReadToEnd();
            }
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
            Services.GetRequiredService<MusicService>().InitializeAsync();
            await Task.Delay(-1);
        }

        private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");
        }

        private async Task Client_Ready()
        {
            Random rnd = new Random();
            
            int gamestatus = rnd.Next(1, 5);
            if (gamestatus == 1)
            {
                await Client.SetGameAsync("Napping on the Job", "");
            }
            if (gamestatus == 2)
            {
                await Client.SetGameAsync("Chopping Trees", "");
            }
            if (gamestatus == 3)
            {
                await Client.SetGameAsync("Mining Gold", "");
            }
            if (gamestatus == 4)
            {
                await Client.SetGameAsync("Building a Barracks", "");
            }
            Console.WriteLine(gamestatus);

        }

        private async Task Client_MessageReceived(SocketMessage MessageParam)
        {
            var Message = MessageParam as SocketUserMessage;
            var Context = new SocketCommandContext(Client, Message);

            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            int ArgPos = 0;

            if (!(Message.HasStringPrefix("!", ref ArgPos) || Message.HasStringPrefix("H", ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;


            var Result = await Commands.ExecuteAsync(Context, ArgPos, null);


            if (!Result.IsSuccess)
            {
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing a command. Text: {Context.Message.Content} | Error: {Result.ErrorReason}");
            }
        }

        private IServiceProvider SetupService()
            => new ServiceCollection()
            .AddSingleton(Client)
            .AddSingleton(Commands)
            .AddSingleton<LavaRestClient>()
            .AddSingleton<LavaSocketClient>()
            .AddSingleton<MusicService>()
            .BuildServiceProvider();
    }
}
