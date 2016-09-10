using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            int StreetNumber = 0;
            string StreetName;
            string City;
            string State;
            int ZipCode = 0;
            string FirstName;
            string LastName;

            List<BookEntry> AddressList = new List<BookEntry>();

            while (choice != 7)
            {
                do
                {
                    choice = 0;
                    StreetNumber = 0;
                    StreetName = "";
                    City = "";
                    State = "";
                    ZipCode = 0;
                    FirstName = "";
                    LastName = "";

                    Console.Clear();
                    Console.WriteLine("Address Book: ");
                    Console.WriteLine("(1) Add entry");
                    Console.WriteLine("(2) Remove entry");
                    Console.WriteLine("(3) Search book");
                    Console.WriteLine("(4) Display all entries");
                    Console.WriteLine("(5) Save current address book");
                    Console.WriteLine("(6) Load an address book");
                    Console.WriteLine("(7) Exit");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                    }
                    if (choice < 1 || choice > 7)
                    {
                        Console.WriteLine("Try again.... Make sure to type a number between 1 and 7!");
                        Console.ReadLine();
                    }
                } while (choice < 1 || choice > 7);

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("What is the street name? (No numbers yet)");
                        StreetName = Console.ReadLine();

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What is the street number?");
                            try
                            {
                                StreetNumber = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                            }
                            if (StreetNumber == 0)
                            {
                                Console.WriteLine("Try again!");
                                Console.ReadLine();
                            }
                        } while (StreetNumber == 0);

                        Console.Clear();
                        Console.WriteLine("What City is this in?");
                        City = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("What state?");
                        State = Console.ReadLine();

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("What is the ZipCode?");
                            try
                            {
                                ZipCode = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                            }
                            if (ZipCode < 10000 || ZipCode > 99999)
                            {
                                Console.WriteLine("I'm sorry, please enter a 5 digit number.");
                                Console.ReadLine();
                            }
                        } while (ZipCode < 10000 || ZipCode > 99999);

                        Console.Clear();
                        Console.WriteLine("Who lives here?");
                        Console.Write("First name: ");
                        FirstName = Console.ReadLine();
                        Console.Write("Last name: ");
                        LastName = Console.ReadLine();

                        AddressList.Add(new BookEntry(StreetNumber, StreetName, City, State, ZipCode, FirstName, LastName));

                        Console.Clear();
                        Console.WriteLine("Entry added: Press ENTER to return to menu");
                        Console.ReadLine();
                        break;
                    case 2:
                        choice = 0;
                        Console.WriteLine("Would you like to delete ");
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        break;
                }
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
