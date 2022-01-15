using Discord_Bro.Menus;

namespace Discord_Bro.Commands
{
    class Command
    {
        public IMenu Menu { get; set; }
        public string Description { get; set; }

        public Command(IMenu menu, string description)
        {
            Menu = menu;
            Description = description;
        }
    }
}
