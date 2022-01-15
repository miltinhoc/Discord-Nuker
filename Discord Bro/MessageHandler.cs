using System;

namespace Discord_Bro
{
    class MessageHandler
    {
        public delegate void ConsoleFunc(string message);

        public static void ShowMessage(string message, ConsoleColor color)
        {
            ConsoleColor original = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ForegroundColor = original;
        }

        public static void ShowMessage(string message, ConsoleColor color, ConsoleFunc func)
        {
            ConsoleColor original = Console.ForegroundColor;
            Console.ForegroundColor = color;

            func(message);

            Console.ForegroundColor = original;
        }

        public static void ShowMultiColorMessage(string[] messages, ConsoleColor[] colors)
        {
            ConsoleColor original = Console.ForegroundColor;

            for (int i = 0; i < messages.Length; i++)
            {
                Console.ForegroundColor = colors[i];
                Console.Write(messages[i]);
            }

            Console.Write("\n");
            Console.ForegroundColor = original;
        }
    }
}
