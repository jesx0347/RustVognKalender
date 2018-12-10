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
                    bool reservation; 
                    Console.WriteLine("Vælg starttidspunkt [dd-mm-yy hh:mm]");
                    string start = Console.ReadLine();
                    Console.WriteLine("Vælg sluttidspunkt [dd-mm-yy hh:mm]");
                    string end = Console.ReadLine();
                    Console.WriteLine("Skal en rustvogn reserveres? [J/N]");
                    reservation = BooleanChoice();
                    Console.WriteLine("Skriv adreesse");
                    string address = Console.ReadLine();
                    Console.WriteLine("Skriv kommentar");
                    string comment = Console.ReadLine();
                    c.CreateEventType(reservation,start,end,address,comment);
                }
                else if (selectedMenuItem == "Rediger Booking")
                {
                    bool reservation;
                    Console.WriteLine("Skriv key");
                    string key = Console.ReadLine();
                    Console.WriteLine("Vælg starttidspunkt [dd-mm-yy hh:mm], eller efterlad tom for ingen endring");
                    string start = Console.ReadLine();
                    Console.WriteLine("Vælg sluttidspunkt [dd-mm-yy hh:mm], eller efterlad tom for ingen endring");
                    string end = Console.ReadLine();
                    Console.WriteLine("Skal en rustvogn reserveres? [J/N], input er desvære nødvendigt her");
                    reservation = BooleanChoice();
                    Console.WriteLine("Skriv adreesse, eller efterlad tom for ingen endring");
                    string address = Console.ReadLine();
                    Console.WriteLine("Skriv kommentar, eller efterlad tom for ingen endring");
                    string coment = Console.ReadLine();
                    c.AlterEvent(key, reservation, start, end, address, coment);

                }
                else if (selectedMenuItem == "Slet Booking")
                {
                    Console.WriteLine("Skriv key");
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
                if (input == "J")
                {
                    return true;
                }
                else if (input == "j")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("J/N");
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