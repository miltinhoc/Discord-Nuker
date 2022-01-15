using Discord_Bro.Commands;
using System.Collections.Generic;

namespace Discord_Bro.Menus.Concrete
{
    class BotStatusMenu : AbstractMenu
    {
        public override void Init()
        {
            MenuContext.showArrow = true;

            options = new Dictionary<string, Command>
            {
                { "1", new Command(new BotStatusGenericMenu(DSharpPlus.Entities.UserStatus.Online), "Online") },
                { "2", new Command(new BotStatusGenericMenu(DSharpPlus.Entities.UserStatus.Offline), "Offline") },
                { "3", new Command(new BotStatusGenericMenu(DSharpPlus.Entities.UserStatus.DoNotDisturb), "Do not Disturb") },
                { "4", new Command(new BotStatusGenericMenu(DSharpPlus.Entities.UserStatus.Invisible), "Invisible") },
                { "5", new Command(new BotStatusGenericMenu(DSharpPlus.Entities.UserStatus.Idle), "Idle") },
                { "6", new Command(new StartMenu(), "Go back") }
            };
        }

        public override void Logic()
        {
            Program.keepRunning = true;
        }
    }
}
