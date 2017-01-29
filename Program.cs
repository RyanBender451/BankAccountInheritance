using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables used before the loop, these are the set ones
            int yourChoice = 0;
            string stringChoice;
            string accountSaveID;
            string accountCheckID;
            string accountResID;
            string mainAccountNum;
            int mainProgramLoop = 1;
            double saveAccountTotals = 0.00;
            double checkAccountTotals = 0.00;
      
            //the base account that passes the name and original Account number
            BaseAccount baseAcct = new BaseAccount("Bob", "Paulson", "1015568");
            mainAccountNum = baseAcct.AccountID;
            accountCheckID = mainAccountNum + "CA";
            accountSaveID = mainAccountNum + "SA";
            accountResID = mainAccountNum + "RA";
            SavingsAccount saveAcct = new SavingsAccount(baseAcct.FirstName, baseAcct.LastName, mainAccountNum, accountSaveID, saveAccountTotals);
            CheckingAccount checkAcct = new CheckingAccount(baseAcct.FirstName, baseAcct.LastName, mainAccountNum, accountCheckID, checkAccountTotals);
            ReserveAccount resAcct = new ReserveAccount(baseAcct.FirstName, baseAcct.LastName, mainAccountNum, accountResID, checkAccountTotals);

            //do-while loop to allow you to go through the bank program mulitple times
            do
            {
                Console.WriteLine("Welcome to Bank");
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
    }
}
