using System;
namespace AddressBookQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddressBook contact = new AddressBook()
            //{
            //    FirstName = "Soundarya",
            //    LastName = "S",
            //    Address = "Chennai",
            //    City = "Chennai",
            //    State = "TN",
            //    Zip = 123456,
            //    PhoneNumber = "1234567890",
            //    Email = "Soundarya@gmail.com"
            //};
            Operations operations = new Operations();
            //operations.AddContact(contact);
            //AddressBook contact1 = new AddressBook()
            //{
            //    FirstName = "Soundarya",
            //    LastName = "S",
            //    Address = "Chennai",
            //    City = "Chennai",
            //    State = "TN",
            //    Zip = 123456,
            //    PhoneNumber = "1234567890",
            //    Email = "Soundarya@gmail.com"
            //};
            //operations.UpdateContact(contact1);
            //operations.DeleteContact("Soundarya");
            //operations.City("Chennai");
            //operations.State("TN");
            //operations.SizeByCity();
            //operations.SizeByState();
            operations.CountByType();
        }
    }
}