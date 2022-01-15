using Discord_Bro.Commands;
using System;
using System.Collections.Generic;

namespace Discord_Bro.Menus.Concrete
{
    class BotGuildsMenu : AbstractMenu
    {
        public override void Init()
        {
            MenuContext.showArrow = false;
            options = new Dictionary<string, Command> { };
        }

        public override void Logic()
        {
            Program.keepRunning = true;

            MessageHandler.ShowMessage(" [Bot Guilds]\n", ConsoleColor.Blue);

            Client.GetBotGuilds();

            MenuContext.currentlySelected = new StartMenu();
        }
    }
}
