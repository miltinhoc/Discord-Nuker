using Discord_Bro.Commands;
using System.Collections.Generic;

namespace Discord_Bro.Menus
{
    interface IMenu
    {
        void Draw();
        Dictionary<string, Command> options { get; set; }
    }
}
