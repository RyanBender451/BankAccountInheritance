using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * This program calls a base class and 3 subclasses based on the main class.
 * The parent class is just called BaseAccount,  It doesn't do much except store the name and Base account ID
 * The 3 child classes (ReserveAccount, CheckingAccount, and SavingsAccount) takes the information given to the BaseAccount first to get the name and the account numbedr
 * Each of the 3 child classes remakes the accountID number to be their own, and then they each save their own amount.  
 * The 3 child classes can add, subtract, display and finally write out the amount in their respective accounts, the accounts do not share thier money with each other
 * The amount is displayed in US currency format so $0.00 is how it would look if it had nothing
 * if you put in a number like 34.679 it would round it up to $34.68
*/

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables used in the main
            int yourChoice = 0;
            string stringChoice;
            string accountSaveID;
            string accountCheckID;
            string accountResID;
            string mainAccountNum;
            string firstName;
            string lastName;
            int mainProgramLoop = 1;
            double saveAccountTotals = 0.00;
            double checkAccountTotals = 0.00;

            //Gets the Name from the user and creates the account number
            Console.WriteLine("Please Enter your first name");
            firstName = Console.ReadLine();
            Console.WriteLine("Please Enter your last name");
            lastName = Console.ReadLine();
            mainAccountNum = MainID();
            //the base account that passes the name and original Account number
            BaseAccount baseAcct = new BaseAccount(firstName, lastName, mainAccountNum);
            accountCheckID = mainAccountNum + "CA";
            accountSaveID = mainAccountNum + "SA";
            accountResID = mainAccountNum + "RA";
            SavingsAccount saveAcct = new SavingsAccount(baseAcct.FirstName, baseAcct.LastName, mainAccountNum, accountSaveID, saveAccountTotals);
            CheckingAccount checkAcct = new CheckingAccount(baseAcct.FirstName, baseAcct.LastName, mainAccountNum, accountCheckID, checkAccountTotals);
            ReserveAccount resAcct = new ReserveAccount(baseAcct.FirstName, baseAcct.LastName, mainAccountNum, accountResID, checkAccountTotals);

            //do-while loop to allow you to go through the bank program mulitple times
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Bob's Bank and Bistro");
                Console.WriteLine("Our Bistro is unaviable at this time so we only have banking options");
                Console.WriteLine("Please Choose your account option");
                Console.WriteLine("(1) Savings \n(2) Checking \n(3) Reserve");
                Console.WriteLine("(4) to quit");
                stringChoice = Console.ReadLine();
                yourChoice = int.Parse(stringChoice);
                // Choice for the savings account
                if (yourChoice == 1)
                {
                    saveAcct.SavingMenu();
                }
                //Checking account option
                else if (yourChoice == 2)
                {
                    checkAcct.CheckingMenu();  
                }
                //Reserve Account opition
                else if (yourChoice == 3)
                {
                    resAcct.ReserveMenu();
                }
                //Quit option
                else
                {
                    Console.WriteLine("Thank you for using this terminal");
                    mainProgramLoop = 0;
                }
            } while (mainProgramLoop == 1);

        }//end main
        static string MainID()
        {
            //Generates the account number using random numbers
            Random rand = new Random();
            int numID;
            string mainID= "";
            for(int i =1; i<=7;i++)
            {
                numID = rand.Next(0, 10);
                mainID = mainID + numID.ToString();
            }
           
            return mainID;
        }//end MainID
    }
}
