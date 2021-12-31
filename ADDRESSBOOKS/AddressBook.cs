using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ADDRESSBOOKS
{
    class AddressBook
    {
        private int countCity = 0, countState = 0;
        private List<Contacts> contacts;
        private static List<Contacts> searchContacts = new List<Contacts>();
        private static List<Contacts> viewContacts = new List<Contacts>();
        //address book dictioanry to store values
        private static Dictionary<string, List<Contacts>> addressBookDictionary = new Dictionary<string, List<Contacts>>();
        public void AddMember()
        {
            string addressBookName;
            contacts = new List<Contacts>();
            while (true)
            {
                Console.WriteLine("Enter The Name of the Address Book");
                addressBookName = Console.ReadLine();
                //Checking uniqueness of address books
                if (addressBookDictionary.Count > 0)
                {
                    if (addressBookDictionary.ContainsKey(addressBookName))
                    {
                        Console.WriteLine("This name of address book already exists");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            Console.Write("Enter Number of contacts you want to add:");
            int numOfContacts = Convert.ToInt32(Console.ReadLine());
            while (numOfContacts > 0)
            {
                //object for person class
                Contacts contact = new Contacts();
                while (true)
                {
                    Console.Write("Enter First Name: ");
                    string FirstName = Console.ReadLine();
                    if (contacts.Count > 0)
                    {
                        var x = contacts.Find(x => x.firstName.Equals(FirstName));
                        if (x != null)
                        {
                            Console.WriteLine("Your name  already exists");
                        }
                        else
                        {
                            contact.firstName = FirstName;
                            break;
                        }
                    }
                    else
                    {
                        contact.firstName = FirstName;
                        break;
                    }
                }
                Console.Write("Enter Last Name: ");
                contact.lastName = Console.ReadLine();
                Console.Write("Enter Address: ");
                contact.address = Console.ReadLine();
                Console.Write("Enter City: ");
                contact.state = Console.ReadLine();
                Console.Write("Enter State: ");
                contact.state = Console.ReadLine();
                Console.Write("Enter Zip Code: ");
                contact.zip = Console.ReadLine();
                Console.Write("Enter phone Number: ");
                contact.phoneNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter EMail: ");
                contact.email = Console.ReadLine();
                contacts.Add(contact);
                numOfContacts--;
            }
            //adding into address book dictionary
            addressBookDictionary.Add(addressBookName, contacts);
            Console.WriteLine("**************Successfully Added****************");
        }

        //method for view Contacts
        public void ViewContacts()
        {
            if (addressBookDictionary.Count > 0)
            {
                //printing the values in address book
                foreach (KeyValuePair<string, List<Contacts>> dict in addressBookDictionary)
                {
                    Console.WriteLine($"******************{dict.Key}*********************");
                    foreach (var addressBook in dict.Value)
                    {
                        PrintValues(addressBook);
                        Console.WriteLine("*******************************************************");
                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }

        }

        //Printing values
        public void PrintValues(Contacts x)
        {
            Console.WriteLine($"First Name : {x.firstName}");
            Console.WriteLine($"Last Name : {x.lastName}");
            Console.WriteLine($"Address : {x.address}");
            Console.WriteLine($"City : {x.city}");
            Console.WriteLine($"State : {x.state}");
            Console.WriteLine($"Zip Code: {x.zip}");
            Console.WriteLine($"Phone Number: {x.phoneNumber}");
            Console.WriteLine($"Email: {x.email}");
        }
        //method for editing details
        public void EditDetails()
        {
            int f;//flag variable
            if (contacts.Count > 0)
            {
                Console.Write("Enter name of a person you want to edit: ");
                string editName = Console.ReadLine();

                foreach (var x in contacts)
                {
                    if (editName.ToLower() == x.firstName.ToLower())
                    {
                        while (true)
                        {
                            f = 0;
                            Console.WriteLine("1.First name\n2.Last name\n3.Address\n4.City\n5.State\n6.ZipCode\n7.Phone Number\n8.email\n9.Exit");
                            Console.WriteLine("Enter Option You want to edit");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 1:
                                    Console.WriteLine("Enter New First name");
                                    x.firstName = Console.ReadLine();
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 2:
                                    Console.WriteLine("Enter New Last name");
                                    x.lastName = Console.ReadLine();
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 3:
                                    Console.WriteLine("Enter New Address");
                                    x.address = Console.ReadLine();
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 4:
                                    Console.WriteLine("Enter New City");
                                    x.city = Console.ReadLine();
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 5:
                                    Console.WriteLine("Enter New State");
                                    x.state = Console.ReadLine();
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 6:
                                    Console.WriteLine("Enter New Zip Code");
                                    x.zip = Console.ReadLine();
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 7:
                                    Console.WriteLine("Enter new Phone Number");
                                    x.phoneNumber = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 8:
                                    Console.WriteLine("Enter New EMail");
                                    x.email = Console.ReadLine();
                                    Console.WriteLine("***************MODIFIED****************");
                                    break;
                                case 9:
                                    // to exit from main method
                                    Console.WriteLine("Exited");
                                    f = 1;
                                    break;
                            }
                            if (f == 1)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entered name is not in Contact list");
                    }
                }
            }
            else
            {
                Console.WriteLine("Your contact list is empty");
            }
        }
        //method for deleting conatcts
        public void DeleteDetails()
        {
            int f = 0;
            if (contacts.Count > 0)
            {
                Console.Write("Enter name of a person you want to Delete: ");
                string deleteName = Console.ReadLine();

                foreach (var x in contacts)
                {
                    if (deleteName.ToLower() == x.firstName.ToLower())
                    {
                        //removing from list
                        Console.WriteLine("***************DELETED****************");
                        Console.WriteLine($"You have deleted {x.firstName} contact");
                        contacts.Remove(x);
                        f = 1;
                        break;
                    }
                }
                if (f == 0)
                {
                    Console.WriteLine("The name you have entered not in the address book");
                }

            }
            else
            {
                Console.WriteLine("Your contact list is empty");
            }
        }
        public void SearchDetails()
        {
            string personName;
            Console.WriteLine("1. Search by city name\n2.Search By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to search:");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByCityName(cityName, personName);
                    break;
                case 2:
                    Console.WriteLine("Enter the state of city in which you want to search:");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByStateName(stateName, personName);
                    break;
                default:
                    return;
            }
        }
        public void CountByStateOrCity()
        {
            Console.WriteLine("1.Count by city name\n2.Count By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to count persons:");
                    string cityName = Console.ReadLine();
                    ViewByCityName(cityName, "count");
                    break;
                case 2:
                    Console.WriteLine("Enter the name of state in which you want to count persons:");
                    string stateName = Console.ReadLine();
                    ViewByStateName(stateName, "count");
                    break;
                default:
                    return;
            }
        }
        public void SearchByCityName(string cityName, string personName)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Contacts>> dict in addressBookDictionary)
                {
                    searchContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(cityName));


                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }
        public void SearchByStateName(string stateName, string personName)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Contacts>> dict in addressBookDictionary)
                {
                    searchContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(stateName));

                }
                if (searchContacts.Count > 0)
                {
                    foreach (var x in searchContacts)
                    {
                        PrintValues(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }
        public void ViewDetailsByStateOrCity()
        {

            Console.WriteLine("1. View by city name\n2.View By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to view:");
                    string cityName = Console.ReadLine();
                    ViewByCityName(cityName, "view");
                    break;
                case 2:
                    Console.WriteLine("Enter the state of city in which you want to view:");
                    string stateName = Console.ReadLine();
                    ViewByStateName(stateName, "view");
                    break;
                default:
                    return;
            }
        }
        public void ViewByCityName(string cityName, string check)
        {
            if (addressBookDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, List<Contacts>> dict in addressBookDictionary)
                {
                    viewContacts = dict.Value.FindAll(x => x.state.Equals(cityName));
                }
                if (check.Equals("view"))
                {
                    if (viewContacts.Count > 0)
                    {
                        foreach (var x in viewContacts)
                        {
                            PrintValues(x);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Details found ");
                    }
                }
                else
                {
                    countCity = viewContacts.Count;
                    Console.WriteLine($"The total persons in {cityName} are : {countCity}");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }

        public void ViewByStateName(string stateName, string check)
        {
            if (addressBookDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, List<Contacts>> dict in addressBookDictionary)
                {
                    viewContacts = dict.Value.FindAll(x => x.state.Equals(stateName));
                }
                if (check.Equals("view"))
                {
                    if (viewContacts.Count > 0)
                    {
                        foreach (var x in viewContacts)
                        {
                            PrintValues(x);
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Details found ");
                    }
                }
                else
                {
                    countState = viewContacts.Count;
                    Console.WriteLine($"The total persons in {stateName} are : {countState}");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }
        public void SortEntriesAlphabetically()
        {
            Console.Write("Enter the name of address book you want to sort: ");
            string addressBookName = Console.ReadLine();


            if (addressBookDictionary.ContainsKey(addressBookName))
            {
                addressBookDictionary[addressBookName].Sort((x, y) => x.firstName.CompareTo(y.firstName));
                ViewContacts();
            }
            else
            {
                Console.WriteLine("This address book doesn't exists ");
            }
        }
        public void SortByCityStateZip()
        {
            Console.Write("Enter the name of address book you want to sort: ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine("\nNow enter \n1. To sort by cities \n2. To sort by State \n3. To sort by Zip-Code");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (addressBookDictionary.ContainsKey(addressBookName))
            {
                switch (choice)
                {
                    case 1:
                        addressBookDictionary[addressBookName].Sort((x, y) => x.city.CompareTo(y.city));
                        break;

                    case 2:
                        addressBookDictionary[addressBookName].Sort((x, y) => x.state.CompareTo(y.state));
                        break;

                    case 3:
                        addressBookDictionary[addressBookName].Sort((x, y) => x.zip.CompareTo(y.zip));
                        break;

                    default:
                        Console.WriteLine("Please enter valid input.");
                        break;
                }

                ViewContacts();
            }
            else
            {
                Console.WriteLine("This address book doesn't exists");
            }
        }
        public void ReadFromFile()
        {
            string filePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\Info.txt";
            try
            {
                string[] fileContents = File.ReadAllLines(filePath);
                var currentAbName = fileContents[0];
                contacts = new List<Contacts>();
                foreach (string i in fileContents.Skip(1))
                {
                    if (i.Contains(","))
                    {
                        Contacts person = new Contacts();
                        string[] line = i.Split(",");
                        person.firstName = line[0];
                        person.lastName = line[1];
                        person.address = line[2];
                        person.city = line[3];
                        person.state = line[4];
                        person.zip = line[5];
                        person.phoneNumber = Convert.ToInt32(line[6]);
                        person.email = line[7];
                        contacts.Add(person);
                    }
                    else
                    {
                        addressBookDictionary.Add(currentAbName, contacts);
                        currentAbName = i;
                        contacts = new List<Contacts>();
                    }
                }
                addressBookDictionary.Add(currentAbName, contacts);
                Console.WriteLine("SuccessFully Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WriteToFile()
        {
            string filePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\Info.txt";

            try
            {
                if (addressBookDictionary.Count > 0)
                {
                    File.WriteAllText(filePath, "Hello");
                    //printing the values in address book
                    foreach (KeyValuePair<string, List<Contacts>> dict in addressBookDictionary)
                    {
                        File.AppendAllText(filePath, $"{dict.Key}\n");
                        foreach (var addressBook in dict.Value)
                        {
                            string text = $"{addressBook.firstName},{addressBook.lastName},{addressBook.address}," +
                                $"{addressBook.city},{addressBook.state},{addressBook.zip},{addressBook.phoneNumber},{addressBook.email}\n";
                            File.AppendAllText(filePath, text);
                        }
                    }
                    Console.WriteLine("successfully stored in file");
                }
                else
                {
                    Console.WriteLine("Address Book is Empty");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ReadandWriteFromCSVFile()
        {
            //initialization
            string importFilePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\import.csv";
            string expoertFilePath = @"C:\Users\CSC\source\repos\ADDRESSBOOKS\ADDRESSBOOKS\export.csv";

            //reading csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contacts>().ToList();
                Console.WriteLine("Read data Successfully from address.csv.");
                foreach ( Contacts con in records)
                {




                    Console.Write("\t", con.firstName);
                    Console.Write("\t", con.lastName);
                    Console.Write("\t", con.email);
                    Console.Write("\t", con.phoneNumber);
                    Console.Write("\t", con.state);


                }

                Console.WriteLine("\n ********** Now Reading from csv file read and write to csv file ********* ");

                //writing csv file
                using (var writer = new StreamWriter(expoertFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
