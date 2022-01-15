using Discord_Bro.Commands;
using DSharpPlus.Entities;
using System.Collections.Generic;

namespace Discord_Bro.Menus.Concrete
{
    class BotStatusGenericMenu : AbstractMenu
    {
        private readonly UserStatus status;

        public BotStatusGenericMenu(UserStatus status)
        {
            this.status = status;
        }

        public override void Init()
        {
            MenuContext.showArrow = false;
            options = new Dictionary<string, Command> { };
        }

        public override void Logic()
        {
            Program.keepRunning = true;
            Client.BotSetStatus(status);

            MenuContext.currentlySelected = new SettingsMenu();
            MenuContext.currentlySelected.Draw();
        }
    }
}
