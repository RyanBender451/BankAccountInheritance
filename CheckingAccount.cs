using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class CheckingAccount : BaseAccount
    {
        private string checkingID;
        private double checkingTotal;
        protected double checkingAdd;
        protected double checkingSub;
        public int checkingChoice;
        public string recieptChecking;
        public string addCheckMoney;
        public string subCheckMoney;
        public int checkingLoop = 1;

        //properties
        public string CheckingID
        {
            get { return this.checkingID; }
            set { this.checkingID = value; }
        }
        public double CheckingTotal
        {
            get { return this.checkingTotal; }
            set { this.checkingTotal = value; }
            
        }
        //Constructors
        public CheckingAccount():base()
        {

        }
        public CheckingAccount(string firstName, string lastName, string accountID, string checkingID, double checkingTotal) : base(firstName,lastName,accountID)
        {
            this.checkingID = checkingID;
            this.checkingTotal = checkingTotal;
        }
        //Methods
        public void CheckingMenu()
        {
            //do-while loop for mult iterations of the menu
            //Reciept is the text file
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to your Checking Account");
                Console.WriteLine("(1) Add money to the account");
                Console.WriteLine("(2) Take out money from the account");
                Console.WriteLine("(3) Check Account Balance");
                Console.WriteLine("(4) Print Reciept and Quit");
                checkingChoice = int.Parse(Console.ReadLine());
                if (checkingChoice == 1)
                {
                    CheckingAddition();
                }
                else if (checkingChoice == 2)
                {
                    CheckingSubtraction();
                }
                else if (checkingChoice == 3)
                {
                    Console.WriteLine(firstName + " " + lastName);
                    Console.WriteLine("Account Number " + checkingID);
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(recieptChecking);
                    System.Threading.Thread.Sleep(3000);


                }
                else
                {
                    CheckReciept(recieptChecking);
                    checkingLoop = 0;
                    Console.Clear();
                }
            } while (checkingLoop == 1);
        }
        public void CheckingAddition()
        {
            Console.WriteLine("How much do you want to add to your Checking");
            CheckingCurrency(checkingTotal);
            addCheckMoney = Console.ReadLine();
            checkingAdd = double.Parse(addCheckMoney);
            checkingTotal = CheckingTotal + checkingAdd;
            
            addCheckMoney = string.Format("{0:C}", checkingAdd);
            recieptChecking = recieptChecking + addCheckMoney + " + " + DateTime.Now + "  " + CheckingCurrency(checkingTotal) + "\n";
            Console.WriteLine(recieptChecking);
            System.Threading.Thread.Sleep(2000);
        }//end addition method
        public void CheckingSubtraction()
        {

            Console.WriteLine("How much do you want to take out of your Checking"); ;
            subCheckMoney = Console.ReadLine();
            checkingSub = double.Parse(subCheckMoney);
            subCheckMoney = string.Format("{0:C}", checkingSub);
            if (checkingTotal >= checkingSub)
            {
                checkingTotal = checkingTotal - checkingSub;
                recieptChecking = recieptChecking + subCheckMoney + " - " + DateTime.Now + "  " + CheckingCurrency(checkingTotal) + "\n";
                Console.WriteLine(recieptChecking);
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("You cannot take out that much, sorry");
                System.Threading.Thread.Sleep(2000);
            }
        }
        //Changes the string to correct currency
        public string CheckingCurrency(double checkingTotal)
        {
            string totalChecking = string.Format("Total in Checking: {0:C}", checkingTotal);
            return totalChecking;
        }
        public void CheckReciept(string reciept)
        {
            Console.WriteLine(recieptChecking);
            StreamWriter writerCheck = new StreamWriter("..\\..\\CheckingAccountInfo.txt");
            using (writerCheck)
            {
                //write a line
                writerCheck.WriteLine(firstName + " " + lastName);
                writerCheck.WriteLine("Account ID:" + accountID);
                writerCheck.WriteLine("Checking ID:" + checkingID);
                writerCheck.WriteLine(reciept);



            }

        }

    }//end class checking
}
