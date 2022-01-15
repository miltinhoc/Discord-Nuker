using Discord_Bro.Commands;
using System.Collections.Generic;

namespace Discord_Bro.Menus.Concrete
{
    class StartMenu : AbstractMenu
    {

        public override void Init()
        {
            MenuContext.showArrow = true;
            options = new Dictionary<string, Command>
                {
                    { "1", new Command(new NukeMenu(), "Nuke Server") },
                    { "2", new Command(new BotGuildsMenu(), "Bot guilds") },
                    { "3", new Command(new SettingsMenu(), "Bot settings") },
                    { "4", new Command(default, "Exit") },
                };
        }

        public override void Logic(){}
    }
}
