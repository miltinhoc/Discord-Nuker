using System;
using System.Collections.Generic;
using System.Reflection;

namespace Discord_Bro
{
    class Header
    {
        private static readonly Dictionary<string, ConsoleColor> logo = new Dictionary<string, ConsoleColor>();
        private static bool isInit;

        static void Init()
        {
            isInit = true;
            logo.Add(@"", Console.ForegroundColor);
            logo.Add(@" ███╗   ██╗██╗   ██╗██╗  ██╗███████╗    ██████╗  ██████╗ ████████╗", ConsoleColor.Cyan);
            logo.Add(@" ████╗  ██║██║   ██║██║ ██╔╝██╔════╝    ██╔══██╗██╔═══██╗╚══██╔══╝", ConsoleColor.Cyan);
            logo.Add(@" ██╔██╗ ██║██║   ██║█████╔╝ █████╗      ██████╔╝██║   ██║   ██║", ConsoleColor.Cyan);
            logo.Add(@" ██║╚██╗██║██║   ██║██╔═██╗ ██╔══╝      ██╔══██╗██║   ██║   ██║ ", ConsoleColor.DarkCyan);
            logo.Add(@" ██║ ╚████║╚██████╔╝██║  ██╗███████╗    ██████╔╝╚██████╔╝   ██║", ConsoleColor.DarkCyan);
            logo.Add(@" ╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝    ╚═════╝  ╚═════╝    ╚═╝", ConsoleColor.DarkCyan);
            logo.Add($" [miltinh0c] & [deflationz] (v{Assembly.GetExecutingAssembly().GetName().Version})\n", ConsoleColor.Red);
        }

        public static void Draw()
        {
            if (!isInit)
            {
                Init();
            }

            ConsoleColor startColor = Console.ForegroundColor;

            foreach (KeyValuePair<string, ConsoleColor> keyValue in logo)
            {
                if (Console.ForegroundColor != keyValue.Value)
                    Console.ForegroundColor = keyValue.Value;

                Console.WriteLine(keyValue.Key);
            }

            Console.ForegroundColor = startColor;
        }
    }
}
