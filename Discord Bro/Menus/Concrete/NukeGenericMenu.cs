using Discord_Bro.Commands;
using System;
using System.Collections.Generic;
using Discord_Bro.Nuke;

namespace Discord_Bro.Menus.Concrete
{
    class NukeGenericMenu : AbstractMenu
    {
        private readonly Nuking.FuncToInvoke func;
        private readonly string description;

        public NukeGenericMenu(Nuking.FuncToInvoke func, string description)
        {
            this.func = func;
            this.description = description;
        }

        public override void Init()
        {
            MenuContext.showArrow = false;
            options = new Dictionary<string, Command> { };
        }

        public override void Logic()
        {
            Program.keepRunning = true;

            MessageHandler.ShowMessage($" [{description}]\n", ConsoleColor.Blue);
            Console.Write(GUILD_STR);

            string guildId = Console.ReadLine();

            Nuking.NukeServer(guildId, new Nuking.FuncToInvoke(func));

            MenuContext.currentlySelected = new NukeMenu();
        }
    }
}
