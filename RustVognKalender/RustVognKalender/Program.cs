using RustVognKalender;
using System;
using System.Collections.Generic;

namespace Console_Menu
{
    class Program
    {
        private static int index = 0;

        private static void Main(string[] args)
        {
            // Create a list of menu items
            List<string> menuItems = new List<string>() {
                "Opret Booking",
                "Rediger Booking",
                "Slet Booking",
                "Afslut program"
            };





            // Remove the flashing line and add functionality to the menu items
            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = drawMenu(menuItems);
                if (selectedMenuItem == "Opret Booking")
                {
                    // Call CreateEvent method
                }
                else if (selectedMenuItem == "Rediger Booking")
                {
                    // Call AlterEvent method 

                }
                else if (selectedMenuItem == "Slet Booking")
                {
                    // Call DeleteEvent method
                }
                else if (selectedMenuItem == "Afslut program")
                {
                    Environment.Exit(0);
                }
            }
        }






        private static string drawMenu(List<string> items)
        {
            // for loop, for counting the items in the list
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }





            // Add functionality to the up, down and enter keys
            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                // stops you from keep going down through the menu.
                if (index == items.Count - 1)
                {

                }
                else { index++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                // stops you from going further up than the menu has items.
                if (index <= 0)
                {

                }
                else { index--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else
            {
                return "";
            }





            Console.Clear();
            return "";
        }
    }
}