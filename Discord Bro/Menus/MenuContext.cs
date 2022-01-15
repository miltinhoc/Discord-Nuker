using System;

namespace Discord_Bro.Menus
{
    class MenuContext
    {
        public static IMenu currentlySelected;
        public static bool showArrow;

        public static void Draw()
        {
            currentlySelected.Draw();

            if (showArrow)
            {
                Console.Write(" -> ");
            }
        }
    }
}
