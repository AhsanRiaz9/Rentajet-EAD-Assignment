using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF18M009_Rentajet
{
    class Program
    {
        static void Main(string[] args)
        {
            int regNo = 0;
            welcome();
            AircraftJet a1 = new AircraftJet(6, "Cesnna", "Citation CJ1", 1, 0, 2408, 6, 720, 2, "Jet", 21800000, 72700);
            AircraftJet a2 = new AircraftJet(6, "Cesnna", "Citation Mustang", 1, 0, 2366, 4, 620, 2, "Jet", 10700000, 42000);
            AircraftJet a3 = new AircraftJet(2, "Cesnna", "Citation CXLR", 2, 1, 4009, 4, 795, 2, "Jet", 24240000, 68000);
            AircraftJet a4 = new AircraftJet(2, "Gulfstream", "GIV SP", 2, 1, 7820, 8, 851, 2, "Jet", 45330000, 278000);
            AircraftJet a5 = new AircraftJet(1, "Bombardier", "Global Express", 2, 8, 12038, 6, 935, 2, "Jet", 51300000, 310000);
            AircraftJet a6 = new AircraftJet(4, "Piper", "Malibu Mirage", 1, 0, 2491, 5, 394, 2, "Turboprop", 6000000, 20000);
            AircraftJet[] aircraftList = new AircraftJet[] { a1, a2, a3, a4, a5, a6 };
            Employee[] empList = new Employee[] { new Employee("Captain", 10000000), new Employee("First Officer", 5500000), new Employee("Flight Attendant", 3300000) };
            /// return;
            Customer customer = new Customer("", "", "");
            string startLoc="A", destLoc="B";
            int numberOfStops = 0;
            int totalDuration = 0;
            int peopleCount = 0;
            string typeOfCharter = "";
            getCustomerDetails(customer);
            int option;
            do
            {
                Console.WriteLine("Please Select 1 to 3, 0 for exit");
                Console.WriteLine("Enter 1 to charter a jet for a single flight from A to B");
                Console.WriteLine("Enter 2 to charter the jet for a flight from A to B with intermediate stops");
                Console.WriteLine("Enter 3 to charter the jet for a specific period of time (e.g. one week)");
                Console.Write("Choose Option: ");
                
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1 || option == 2)
                {
                    customer.typeOfCharterTransaction = "Single Flight";
                    Console.Write("Enter Start Locatoin: ");
                    startLoc = Console.ReadLine();
                    Console.Write("Enter Destination Locatoin: ");
                    destLoc = Console.ReadLine();
                    Console.Write("Enter Number of people: ");
                    peopleCount = Convert.ToInt32(Console.ReadLine());
                    option = 0;
                    typeOfCharter = "Single Flight";
                }
                if (option == 2)
                {
                    customer.typeOfCharterTransaction = "Flight With Stopovers";
                    Console.Write("Enter Number of Stopovers: ");
                    numberOfStops = Convert.ToInt32(Console.ReadLine());
                    typeOfCharter = "Flight with stopovers";
                    option = 0;
                }
                else if (option == 3)
                {
                    customer.typeOfCharterTransaction = "Time Charter";
                    Console.Write("Enter Time Duration in number of Hours: ");
                    totalDuration = Convert.ToInt32(Console.ReadLine());
                    typeOfCharter = "Time Charter";
                    option = 0;
                }
            }
            while (option != 0);
            string startDate, lastDate;
            System.Console.Write("Enter Start Date dd/mm/yyyy : ");
            startDate = System.Console.ReadLine();
            System.Console.Write("Enter Last Date dd/mm/yyyy : ");
            lastDate = System.Console.ReadLine();
            Console.WriteLine("Select Aircrafft 1 to 6");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine((i + 1) + ". " + aircraftList[i].manufacturer + " with type " + aircraftList[i].type + " max distance " + aircraftList[i].range);
            }
            int index;
            Console.Write("Choose Aircraft(1-6):  ");
            index = Convert.ToInt32(Console.ReadLine());
            index--;
            double totalCost = 0;
            if (index >= 0 && index < 6)
            {
                totalCost = aircraftList[index].annualFixedCost + getPersonnelCost(empList) + aircraftList[index].hourlyRate * aircraftList[index].range;
            }
            Console.WriteLine("Total Cost is " + totalCost);
            Console.Write("Do you want to accept this offer(y/n): ");
            string choice = "";
            choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                Console.WriteLine("Your offer appcted");
                GeneratePDF.createPDF1("file1.pdf",customer,aircraftList[index],regNo,startDate, lastDate, startLoc, destLoc,totalCost);
                GeneratePDF.createPDF2("file2.pdf", customer, aircraftList[index], regNo, startDate, lastDate, startLoc, destLoc, totalCost);
                regNo++;
                Console.WriteLine("PDF file is generated you can check");
            }
            else
            {
                Console.WriteLine("Your offer rejected ");
            }
            goodByeMsg();

        }
        static void welcome()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("                 Welcome to Rentajet System               ");
            Console.WriteLine("***********************************************************");
        }
        static void goodByeMsg()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("      Good bye, Thanks for using to Rentajet System        ");
            Console.WriteLine("***********************************************************");
        }
        static double getPersonnelCost(Employee [] empList)
        {
            double cost = 0;
            for(int i=0;i<3;i++)
            {
                cost = cost + empList[i].personalCost();
            }
            return cost;
        }
        static void getCustomerDetails(Customer customer)
        {
            String name;
            string contact;
            Console.WriteLine("************** Customer Details *************");
            Console.Write("Enter Customer Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Customer Contact Number: ");
            contact = Console.ReadLine();
            customer.name = name;
            customer.contact = contact;
        }
    }
}
