using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

            while (choice != 8)
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
                    Console.WriteLine("(3) Sort Book");
                    Console.WriteLine("(4) Search book");
                    Console.WriteLine("(5) Display all entries");
                    Console.WriteLine("(6) Save current address book");
                    Console.WriteLine("(7) Load an address book");
                    Console.WriteLine("(8) Exit");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                    }
                    if (choice < 1 || choice > 8)
                    {
                        Console.WriteLine("Try again.... Make sure to type a number between 1 and 8!");
                        Console.ReadLine();
                    }
                } while (choice < 1 || choice > 8);

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddAddress(ref StreetNumber, out StreetName, out City, out State, ref ZipCode, out FirstName, out LastName, AddressList);
                        break;
                    case 2:
                        choice = 0;
                        do
                        {
                            Console.Clear();
                            choice = 0;
                            Console.WriteLine("Would you like to delete by: ");
                            Console.WriteLine("(1) First Name");
                            Console.WriteLine("(2) Last Name");
                            Console.WriteLine("(3) Both");
                            try
                            {
                                choice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                            }
                            if (choice < 1 || choice > 3)
                            {
                                Console.WriteLine("Try again, make sure you type a number between 1 and 3");
                                Console.ReadLine();
                            }
                        } while (choice < 1 || choice > 3);

                        Console.Clear();
                        Console.WriteLine("Name to delete:");
                        string response = Console.ReadLine();
                        Console.Clear();

                        switch (choice)
                        {
                            case 1:
                                int nameRemoved = 0;
                                for (int i = AddressList.Count - 1; i >= 0; i--)
                                {
                                    if (AddressList[i].GetFirstName() == response)
                                    {
                                        AddressList.RemoveAt(i);
                                        nameRemoved++;
                                    }
                                }
                                if (nameRemoved == 0)
                                    Console.WriteLine("No entries named " + response + " found... Press ENTER to return to the menu");
                                else if (nameRemoved == 1)
                                    Console.WriteLine("One " + response + " removed from book. Press ENTER to return to the menu");
                                else
                                    Console.WriteLine(nameRemoved + " " + response + "s removed from book. Press ENTER to return to the menu");
                                Console.ReadLine();
                                break;
                            case 2:
                                nameRemoved = 0;
                                for (int i = AddressList.Count - 1; i > 0; i--)
                                {
                                    if (AddressList[i].GetLastName() == response)
                                    {
                                        AddressList.RemoveAt(i);
                                        nameRemoved++;
                                    }
                                }
                                if (nameRemoved == 0)
                                    Console.WriteLine("No entries named " + response + " found... Press ENTER to return to the menu");
                                else if (nameRemoved == 1)
                                    Console.WriteLine("One " + response + " removed from book. Press ENTER to return to the menu");
                                else
                                    Console.WriteLine(nameRemoved + " " + response + "s removed from book. Press ENTER to return to the menu");
                                Console.ReadLine();
                                break;
                            case 3:
                                nameRemoved = 0;
                                for (int i = AddressList.Count - 1; i > 0; i--)
                                {
                                    if (AddressList[i].GetFirstName() + " " + AddressList[i].GetLastName() == response)
                                    {
                                        AddressList.RemoveAt(i);
                                        nameRemoved++;
                                    }
                                }
                                if (nameRemoved == 0)
                                    Console.WriteLine("No entries named " + response + " found... Press ENTER to return to the menu");
                                else if (nameRemoved == 1)
                                    Console.WriteLine("One " + response + " removed from book. Press ENTER to return to the menu");
                                else
                                    Console.WriteLine(nameRemoved + " " + response + "s removed from book. Press ENTER to return to the menu");
                                Console.ReadLine();

                                break;
                            default:
                                break;
                        }
                        break;

                    case 3:
                        choice = 0;
                        do
                        {
                            Console.Clear();
                            choice = 0;
                            Console.WriteLine("Would you like to sort by: ");
                            Console.WriteLine("(1) First Name");
                            Console.WriteLine("(2) Last Name");
                            Console.WriteLine("(3) Both");
                            try
                            {
                                choice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                            }
                            if (choice < 1 || choice > 3)
                            {
                                Console.WriteLine("Try again, make sure you type a number between 1 and 3");
                                Console.ReadLine();
                            }
                        } while (choice < 1 || choice > 3);

                        switch (choice)
                        {
                            case 1:
                                for (int i = 0; i < AddressList.Count; i++)
                                {
                                    int j = i;
                                    BookEntry tmp = new BookEntry();
                                    while (j > 0 && AddressList[j].GetFirstName().CompareTo(AddressList[j - 1].GetFirstName()) < 0)
                                    {
                                        int compare = AddressList[j].GetFirstName().CompareTo(AddressList[j - 1].GetFirstName());
                                        tmp = AddressList[j];
                                        AddressList[j] = AddressList[j - 1];
                                        AddressList[j - 1] = tmp;
                                        j--;
                                    }
                                }
                                break;
                            case 2:
                                for (int i = 0; i < AddressList.Count; i++)
                                {
                                    int j = i;
                                    BookEntry tmp = new BookEntry();
                                    while (j > 0 && AddressList[j].GetLastName().CompareTo(AddressList[j - 1].GetLastName()) < 0)
                                    {
                                        int compare = AddressList[j].GetLastName().CompareTo(AddressList[j - 1].GetLastName());
                                        tmp = AddressList[j];
                                        AddressList[j] = AddressList[j - 1];
                                        AddressList[j - 1] = tmp;
                                        j--;
                                    }
                                }
                                break;
                            case 3:
                                for (int i = 0; i < AddressList.Count; i++)
                                {
                                    int j = i;
                                    BookEntry tmp = new BookEntry();
                                    while (j > 0 && (AddressList[j].GetFirstName() + " " + AddressList[j].GetLastName()).CompareTo(
                                        (AddressList[j - 1].GetFirstName() + " " + AddressList[j - 1].GetLastName())) < 0)
                                    {
                                        int compare = (AddressList[j].GetFirstName() + " " + AddressList[j].GetLastName()).CompareTo(
                                            (AddressList[j - 1].GetFirstName() + " " + AddressList[j - 1].GetLastName()));
                                        tmp = AddressList[j];
                                        AddressList[j] = AddressList[j - 1];
                                        AddressList[j - 1] = tmp;
                                        j--;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        do
                        {
                            Console.Clear();
                            choice = 0;
                            Console.WriteLine("Would you like to search by: ");
                            Console.WriteLine("(1) First Name");
                            Console.WriteLine("(2) Last Name");
                            Console.WriteLine("(3) Both");
                            try
                            {
                                choice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                            }
                            if (choice < 1 || choice > 3)
                            {
                                Console.WriteLine("Try again, make sure you type a number between 1 and 3");
                                Console.ReadLine();
                            }
                        } while (choice < 1 || choice > 3);

                        Console.Clear();
                        Console.WriteLine("Name to search for:");
                        response = Console.ReadLine();
                        Console.Clear();

                        switch (choice)
                        {
                            case 1:
                                for (int i = 0; i < AddressList.Count; i++)
                                {
                                    if (AddressList[i].GetFirstName() == response)
                                        AddressList[i].Show();
                                }
                                break;
                            case 2:
                                for (int i = 0; i < AddressList.Count; i++)
                                {
                                    if (AddressList[i].GetLastName() == response)
                                        AddressList[i].Show();
                                }
                                break;
                            case 3:
                                for (int i = 0; i < AddressList.Count; i++)
                                {
                                    if ((AddressList[i].GetFirstName() + " " + AddressList[i].GetLastName()) == response)
                                        AddressList[i].Show();
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 5:
                        Console.Clear();
                        for (int i = 0; i < AddressList.Count; i++)
                            AddressList[i].Show();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Press ENTER to return to the menu");
                        Console.ReadLine();
                        break;
                    case 6:
                        do
                        {
                            Console.Clear();
                            choice = 0;
                            Console.WriteLine("Would you like to save as a: ");
                            Console.WriteLine("(1) txt file");
                            Console.WriteLine("(2) csv file");
                            try
                            {
                                choice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                            }
                            if (choice < 1 || choice > 2)
                            {
                                Console.WriteLine("Try again, make sure you type a number between 1 and 2");
                                Console.ReadLine();
                            }
                        } while (choice < 1 || choice > 2);
                        Console.Clear();
                        Console.WriteLine("What would you like to name the save file?");
                        response = Console.ReadLine();
                        string fileType;
                        if (choice == 1)
                            fileType = ".txt";
                        else
                            fileType = ".csv";
                        FileStream fileCreate = new FileStream((response + fileType), FileMode.OpenOrCreate);
                        StreamWriter entry = new StreamWriter((response + fileType));
                        for (int i = 0; i < AddressList.Count; i++)
                        {
                            AddressList[i].Show();
                            entry.Write(',');
                        }
                        entry.Close();
                        fileCreate.Close();
                        Console.Clear();
                        break;
                    case 7:
                        do
                        {
                            choice = 0;
                            Console.WriteLine("What type of file would you like to load?");
                            Console.WriteLine("(1) txt");
                            Console.WriteLine("(2) csv");
                            try
                            {
                                choice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                            }
                            if (choice != 1 && choice != 2)
                            {
                                Console.WriteLine("Try again. Type either 1 or 2 for your choice");
                                Console.ReadLine();
                            }
                            Console.Clear();
                        } while (choice != 1 && choice != 2);

                        if (choice == 1)
                            fileType = ".txt";
                        else
                            fileType = ".csv";

                        Console.WriteLine("What is the name of the file you would like to load?");
                        string fileName = Console.ReadLine();

                        StreamReader loadFile = new StreamReader((fileName + fileType));
                        string loadedFile = loadFile.ReadLine();
                        string[] splitLoad = loadedFile.Split(',');
                        for (int i = 0; i < splitLoad.Length; i++)
                        {
                            AddressList.Add(splitLoad[i]);
                        }

                        break;
                    case 8:
                        Console.WriteLine("Hope to see you again soon!");
                        break;
                    default:
                        break;
                }
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }

        private static void AddAddress(ref int StreetNumber, out string StreetName, out string City,
            out string State, ref int ZipCode, out string FirstName, out string LastName, List<BookEntry> AddressList)
        {
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
        }
    }
}
