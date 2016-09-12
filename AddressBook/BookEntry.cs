using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class BookEntry
    {
        int StreetNumber;
        string StreetName;
        string City;
        string State;
        int ZipCode;
        string FirstName;
        string LastName;

        public BookEntry()
        {

        }

        public BookEntry(int StrNum, string StrName, string Town, string stat, int ZC, string FN, string LN)
        {
            StreetNumber = StrNum;
            StreetName = StrName;
            City = Town;
            State = stat;
            ZipCode = ZC;
            FirstName = FN;
            LastName = LN;
        }

        public int GetStreetNumber()
        {
            return StreetNumber;
        }

        public string GetStreetName()
        {
            return StreetName;
        }

        public string GetCity()
        {
            return City;
        }

        public string GetState()
        {
            return State;
        }

        public int GetZipCode()
        {
            return ZipCode;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public void Show()
        {
            Console.WriteLine("Name: " + FirstName + " " + LastName + "     Address: " + StreetNumber + " " + StreetName);
            Console.WriteLine("     City: " + City + "     State: " + State + "     ZipCode: " + ZipCode);
        }
    
    }
}
