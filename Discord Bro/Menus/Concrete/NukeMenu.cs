using Discord_Bro.Commands;
using System.Collections.Generic;
using Discord_Bro.Nuke;

namespace Discord_Bro.Menus.Concrete
{
    class NukeMenu : AbstractMenu
    {

        public override void Init()
        {
            MenuContext.showArrow = true;
            options = new Dictionary<string, Command>
            {
                { "1", new Command(new NukeGenericMenu(Nuking.DeleteAllChannels, "Delete channels"), "Delete all channels") },
                { "2", new Command(new NukeGenericMenu(Nuking.DeleteRoles, "Delete all roles"), "Delete all roles") },
                { "3", new Command(new NukeGenericMenu(Nuking.CreateSpamChannels, "Create channels"), "Mass create channels") },
                { "4", new Command(new NukeGenericMenu(Nuking.CreateAdminRole, "Create admin role"), "Give user admin role") },
                { "5", new Command(new NukeGenericMenu(Nuking.DeleteEmojis, "Delete emojis"), "Delete all emojis") },
                { "6", new Command(new NukeGenericMenu(Nuking.BanAllMembers, "Ban members"), "Ban all members" )},
                { "7", new Command(new NukeGenericMenu(Nuking.KickAllMembers, "Kick members"), "Kick all members" )},
                { "8", new Command(new NukeGenericMenu(Nuking.SendMessageToUsers, "Send message to members"), "Mass dm members" )},
                { "9", new Command(new StartMenu(), "Go back") }
            };
        }

        public override void Logic()
        {
           
        }
    }
}
