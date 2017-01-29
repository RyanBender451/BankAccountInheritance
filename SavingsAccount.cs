using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount 
{
    class SavingsAccount : BaseAccount
    {
        private string savingsID;
        private double savingsTotal;
        protected double savingsAdd;
        protected double savingsSub;
        public int SavingsChoice;
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
        //methods
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
                SavingsChoice = int.Parse(Console.ReadLine());
                if (SavingsChoice == 1)
                {
                    SavingsAddition();
                }
                else if (SavingsChoice == 2)
                {
                    SavingsSubtraction();
                }
                else if (SavingsChoice == 3)
                {
                    Console.WriteLine(firstName + " " + lastName);
                    Console.WriteLine("Account Number "+ SavingsID);
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(recieptSavings);
                    SavingCurrency(savingsTotal);
                    System.Threading.Thread.Sleep(3000);


                }
                else
                {
                    SavingReciept(recieptSavings);  
                    savingLoop = 0;
                    Console.Clear();
                }

            } while (savingLoop == 1);

        }
        public void SavingsAddition()
        {
           
            Console.WriteLine("How much do you want to add to your savings");
            addSaveMoney = Console.ReadLine();
            savingsAdd = double.Parse(addSaveMoney);
            savingsTotal = savingsTotal + savingsAdd;
          //  SavingCurrency(savingsTotal);

            addSaveMoney = string.Format("{0:C}", savingsAdd);
            recieptSavings = recieptSavings  + addSaveMoney + " + " + DateTime.Now + "  " + SavingCurrency(savingsTotal) +"\n" ;
            Console.WriteLine(recieptSavings);
            System.Threading.Thread.Sleep(2000);
            
        }
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
               Console.WriteLine(recieptSavings);
               System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("You cannot take out that much, sorry");
                System.Threading.Thread.Sleep(2000);
            }
           

        }
        public string SavingCurrency(double savingsTotal)
        {
         string totalSavings= string.Format("Total in Savings: {0:C}", savingsTotal);
            // Console.WriteLine(totalSavings);
            return totalSavings;
        }
        public void SavingReciept(string reciept)
        {
            Console.WriteLine(recieptSavings);
            StreamWriter writerSave = new StreamWriter("..\\..\\SavingAccountInfo.txt");
            using (writerSave)
            {
                //write a line
                writerSave.WriteLine(firstName + " " + lastName);
                writerSave.WriteLine("Account ID:" + accountID);
                writerSave.WriteLine("Savings ID:" + savingsID);
                writerSave.WriteLine(reciept);



            }
        }
    
    }//end Saving class
}
