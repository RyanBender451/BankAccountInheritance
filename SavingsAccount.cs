﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount 
{
    class SavingsAccount : BaseAccount
    {
        //vars used
        private string savingsID;
        private double savingsTotal;
        protected double savingsAdd;
        protected double savingsSub;
        public int savingsChoice;
        public string addSaveMoney;
        public string subSaveMoney;
        public string recieptSavings;
        public int savingLoop = 1;
        
        //Properties
        public string SavingsID
        {
            get { return this.savingsID; }
            set { this.savingsID = value; }
        }
        public double SavingsTotal
        {
            get { return this.savingsTotal; }
            set { this.savingsTotal = value; }
        }
        // Constructors
        public SavingsAccount():base()
        {

        }
        public SavingsAccount(string firstName,string lastName,string accountID, string savingsID, double savingsTotal) : base(firstName,lastName,accountID)
        {
            this.savingsID = savingsID;
            this.savingsTotal = savingsTotal;
        }
        //Methods
        public void SavingMenu()
        {
            //do-while loop for multiple iterations through the menu
            //Reciept is the text file
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Savings Menu");
                Console.WriteLine("(1) Add money to the account");
                Console.WriteLine("(2) Take out money from the account");
                Console.WriteLine("(3) See how much is in your Account");
                Console.WriteLine("(4) Quit and Print out Reciept");
                Console.WriteLine("Enter your choice below");
                savingsChoice = int.Parse(Console.ReadLine());
                if (savingsChoice == 1)
                {
                    savingLoop = 1;
                    SavingsAddition();
                }
                else if (savingsChoice == 2)
                {
                    savingLoop = 1;
                    SavingsSubtraction();
                }
                else if (savingsChoice == 3)
                {
                    //Displays account info
                    savingLoop = 1;
                    Console.WriteLine(firstName + " " + lastName);
                    Console.WriteLine("Savings Account");
                    Console.WriteLine("Account Number "+ savingsID);
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(recieptSavings);
                    Console.WriteLine("------------------");
                    Console.WriteLine(SavingCurrency(savingsTotal));
             
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    SavingReciept(recieptSavings);  
                    savingLoop = 0;
                    Console.Clear();
                }

            } while (savingLoop == 1);

        }//end menu
        public void SavingsAddition()
        {
            Console.WriteLine("How much do you want to add to your savings");
            addSaveMoney = Console.ReadLine();
            savingsAdd = double.Parse(addSaveMoney);
            savingsTotal = savingsTotal + savingsAdd;

            addSaveMoney = string.Format("{0:C}", savingsAdd);
            recieptSavings = recieptSavings  + addSaveMoney + " + " + DateTime.Now + "  " + SavingCurrency(savingsTotal) +"\n" ;
            Console.WriteLine(firstName + " "+ lastName + "'s Account" );
            Console.WriteLine("Account type: Savings");
            Console.WriteLine(recieptSavings);
            System.Threading.Thread.Sleep(2000);
            
        }//end addition
        public void SavingsSubtraction()
        {
            Console.WriteLine("How much to take out of Savings?");
            SavingCurrency(savingsTotal);
            subSaveMoney = Console.ReadLine();
            savingsSub = double.Parse(subSaveMoney);
            subSaveMoney = string.Format("{0:C}", savingsSub);
            if (savingsTotal >= savingsSub)
            {
               savingsTotal = savingsTotal - savingsSub;
               
                
               recieptSavings = recieptSavings + subSaveMoney + " - " + DateTime.Now + "  "+ SavingCurrency(savingsTotal) + "\n";
                Console.WriteLine(firstName + " " + lastName + "'s Account");
                Console.WriteLine("Account type: Savings");
                Console.WriteLine(recieptSavings);
               System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("You cannot take out that much, sorry");
                System.Threading.Thread.Sleep(2000);
            }
           

        }//end subrtaction
        public string SavingCurrency(double savingsTotal)
        {
         string totalSavings= string.Format("Total in Savings: {0:C}", savingsTotal);
            // Console.WriteLine(totalSavings);
            return totalSavings;
        }//end currency
        public void SavingReciept(string reciept)
        {
            Console.WriteLine(recieptSavings);
            StreamWriter writerSave = new StreamWriter("..\\..\\obj\\Debug\\SavingAccountInfo.txt");
            using (writerSave)
            {
                //write a line
                writerSave.WriteLine(firstName + " " + lastName);
                writerSave.WriteLine("Account ID:" + accountID);
                writerSave.WriteLine("Savings ID:" + savingsID);
                writerSave.WriteLine(reciept);
            }
        }//end savingreciept
    
    }//end Saving class
}
