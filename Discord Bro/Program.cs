using Discord_Bro.Configs;
using Discord_Bro.Menus;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Discord_Bro.Menus.Concrete;
using System.Runtime.InteropServices;

namespace Discord_Bro
{
    class Program
    {
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);

        private delegate bool SetConsoleCtrlEventHandler(CtrlType sig);

        private enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        public static Configuration configuration;
        public static volatile bool keepRunning = true;
        private static volatile bool showMenu = true;

        static void Main(string[] args)
        {

            if (!LoadConfigs())
            {
                MessageHandler.ShowMessage(" [*] Error loading configuration file!", ConsoleColor.Red);
                Console.Read();
                return;
            }

            Console.CancelKeyPress += Console_CancelKeyPress;
            Task t = Client.MainAsync();

            SetConsoleCtrlHandler(Handler, true);

            if (t.IsFaulted)
            {
                MessageHandler.ShowMessage($" [*] {t.Exception.Message}", ConsoleColor.Red);
                Console.ReadKey();
                return;
            }
            
            MenuContext.currentlySelected = new StartMenu();
            MenuLoop();

            Client.DiscordClient.DisconnectAsync().Wait();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            keepRunning = false;
        }

        private static void MenuLoop()
        {
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool Handler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    TryDisconnect();
                    Environment.Exit(0);
                    return false;
                default:
                    return false;
            }
        }

        private static void TryDisconnect()
        {
            try
            {
                Client.DiscordClient.DisconnectAsync().Wait();
            }
            catch (Exception) { }
        }

        private static bool MainMenu()
        {
            MenuContext.Draw();

            try
            {
                MenuContext.currentlySelected = MenuContext.currentlySelected.options[Console.ReadLine()]?.Menu;
            }
            catch (Exception){}

            return MenuContext.currentlySelected != default;
        }

        private static bool LoadConfigs()
        {
            string filename = "configs.json";

            try
            {
                if (!File.Exists(filename))
                {
                    string filecontent = JsonConvert.SerializeObject(new Configuration(), Formatting.Indented);
                    File.WriteAllText(filename, filecontent);

                    return false;
                }
                
                string json = File.ReadAllText(filename);
                configuration = JsonConvert.DeserializeObject<Configuration>(json);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
