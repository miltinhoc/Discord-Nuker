using Discord_Bro.Commands;
using Discord_Bro.Nuke;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discord_Bro.Menus.Concrete
{
    class SettingsMenu : AbstractMenu
    {
        public override void Init()
        {
            MenuContext.showArrow = true;
            options = new Dictionary<string, Command>
            {
                //{ "1", new Command(new BotActivityMenu(), "Bot activity") },
                { "1", new Command(new BotStatusMenu(), "Bot status") },
                { "2", new Command(new StartMenu(), "Go back") }
            };
        }

        public override void Logic()
        {
        }
    }
}
