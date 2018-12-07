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
            Controller c = new Controller();
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
                    bool resavation; 
                    Console.WriteLine("vælg starttidspunkt [dd-mm-yy hh:mm]");
                    string start = Console.ReadLine();
                    Console.WriteLine("vælg sluttidspunkt [dd-mm-yy hh:mm]");
                    string end = Console.ReadLine();
                    Console.WriteLine("skal en rustvogn resaveres [y/n]");
                    resavation = BooleanChoice();
                    Console.WriteLine("skriv adreesse");
                    string address = Console.ReadLine();
                    Console.WriteLine("skriv kommentar");
                    string coment = Console.ReadLine();
                    c.CreateEventType(resavation,start,end,address,coment);
                }
                else if (selectedMenuItem == "Rediger Booking")
                {
                    bool resavation;
                    Console.WriteLine("skriv key");
                    string key = Console.ReadLine();
                    Console.WriteLine("vælg starttidspunkt [dd-mm-yy hh:mm], eller efterlad tom for ingen endring");
                    string start = Console.ReadLine();
                    Console.WriteLine("vælg sluttidspunkt [dd-mm-yy hh:mm], eller efterlad tom for ingen endring");
                    string end = Console.ReadLine();
                    Console.WriteLine("skal en rustvogn resaveres [y/n], input er desvære nødvendigt her");
                    resavation = BooleanChoice();
                    Console.WriteLine("skriv adreesse, eller efterlad tom for ingen endring");
                    string address = Console.ReadLine();
                    Console.WriteLine("skriv kommentar, eller efterlad tom for ingen endring");
                    string coment = Console.ReadLine();
                    c.AlterEvent(key, resavation, start, end, address, coment);

                }
                else if (selectedMenuItem == "Slet Booking")
                {
                    Console.WriteLine("skriv key");
                    string key = Console.ReadLine();
                    c.DeleteEvent(key);
                }
                else if (selectedMenuItem == "Afslut program")
                {
                    Environment.Exit(0);
                }
            }
            bool BooleanChoice()
            {
                string input = Console.ReadLine();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("skriv y eller n");
                    bool ans = BooleanChoice();
                    return ans;
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