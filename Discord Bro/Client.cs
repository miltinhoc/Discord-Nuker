using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discord_Bro
{
    class Client
    {
        public struct BotGuild
        {
            public DiscordGuild Guild { get; }
            public ulong Id => Guild.Id;

            public BotGuild(DiscordGuild gld)
            {
                Guild = gld;
            }

            public override string ToString()
            {
                return Guild.Name;
            }
        }

        private static List<BotGuild> botGuilds;
        public static DiscordClient DiscordClient;

        public static async Task MainAsync()
        {
            botGuilds = new List<BotGuild>();

            var config = new DiscordConfiguration
            {
                Token = Program.configuration.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.None,
                Intents = DiscordIntents.AllUnprivileged
            };

            DiscordClient = new DiscordClient(config);

            DiscordClient.GuildAvailable += DiscordClient_GuildAvailable;
            DiscordClient.GuildCreated += DiscordClient_GuildCreated;

            await DiscordClient.ConnectAsync(new DiscordActivity("Hunger Games", ActivityType.Playing), UserStatus.Online);
            await Task.Delay(-1);
        }

        private static Task DiscordClient_GuildCreated(DiscordClient sender, GuildCreateEventArgs e)
        {
            botGuilds.Add(new BotGuild(e.Guild));
            return Task.CompletedTask;
        }

        private static Task DiscordClient_GuildAvailable(DiscordClient sender, GuildCreateEventArgs e)
        {
            botGuilds.Add(new BotGuild(e.Guild));
            return Task.CompletedTask;
        }

        public delegate void FuncToInvoke(UserStatus status);

        public static void BotSetStatus(UserStatus status)
        {
            try
            {
                DiscordClient.UpdateStatusAsync(new DiscordActivity("Hunger Games", ActivityType.Playing), status).Wait();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static ulong GetBotId() => DiscordClient.CurrentUser.Id;

        public static void GetBotGuilds()
        {
            foreach (BotGuild guild in botGuilds)
            {
                MessageHandler.ShowMultiColorMessage(new string[] { $" [{guild.Guild.Name}] - ", guild.Id.ToString() }, new ConsoleColor[] { ConsoleColor.Gray, ConsoleColor.Cyan });
            }

            MessageHandler.ShowMessage("\n[*] Press Enter to go back!", ConsoleColor.Green);
        }

        public static DiscordGuild GetGuildById(string guildId)
        {
            foreach (BotGuild guild in botGuilds)
            {
                if (guild.Id.ToString() == guildId)
                {
                    return guild.Guild;
                }
            }

            return default;
        }
    }
}
