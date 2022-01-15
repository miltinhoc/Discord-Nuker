using Discord_Bro.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Discord_Bro.Menus
{
    abstract class AbstractMenu : IMenu
    {
        public static readonly string GUILD_STR = " [*] Guid Id -> ";
        public static Dictionary<string, Command> options;
        Dictionary<string, Command> IMenu.options { get => options; set => options = value; }

        public abstract void Init();
        public abstract void Logic();

        public void Draw()
        {
            Init();

            Console.ForegroundColor = ConsoleColor.White;

            if (options.Count > 0)
            {
                KeyValuePair<string, Command> last = options.Last();

                foreach (KeyValuePair<string, Command> keyValue in options)
                {
                    if (keyValue.Key == last.Key)
                    {
                        Console.WriteLine();
                    }

                    MessageHandler.ShowMessage($" [{keyValue.Key}] - ", ConsoleColor.Cyan, Console.Write);
                    Console.WriteLine(keyValue.Value.Description);
                }
            }
            
        }

        void IMenu.Draw()
        {
            Console.Clear();
            Header.Draw();

            Draw();
            Logic();
        }
    }
}
