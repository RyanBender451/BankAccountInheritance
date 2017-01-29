using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class ReserveAccount : BaseAccount
    {
        //vars used
        private string reserveID;
        private double reserveTotal;
        protected double reserveAdd;
        protected double reserveSub;
        public int reserveChoice;
        public string recieptReserve;
        public string addReserveMoney;
        public string subReserveMoney;
        public int reserveLoop = 1;
       
        //properties
        public string ReserveID
        {
            get { return this.reserveID; }
            set { this.reserveID = value; }
        }
        public double ReserveTotal
        {
            get { return this.reserveTotal; }
            set { this.reserveTotal = value; }
        }
        // constructors 
        public ReserveAccount():base()
        {

        }
        public ReserveAccount(string firstName, string lastName, string accountID, string reserveID, double reserveTotal) : base(firstName, lastName, accountID)
        {
            this.reserveID = reserveID;
            this.reserveTotal = reserveTotal;
        }
        //Methods
        public void ReserveMenu()
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
                Console.WriteLine("(4) Print Reciept and Quit");
                Console.WriteLine("Enter your choice below");
                reserveChoice = int.Parse(Console.ReadLine());
                if (reserveChoice == 1)
                {
                    reserveLoop = 1;
                    ReserveAddition();
                }
                else if (reserveChoice == 2)
                {
                    reserveLoop = 1;
                    ReserveSubtraction();
                }
                else if (reserveChoice == 3)
                {
                    //Displays account info
                    reserveLoop = 1;
                    Console.WriteLine(firstName + " " + lastName);
                    Console.WriteLine("Reserve Account");
                    Console.WriteLine("Account Number " + reserveID);
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(recieptReserve);
                    Console.WriteLine("------------------");
                    Console.WriteLine(ReserveCurrency(reserveTotal));
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    ReserveReciept(recieptReserve);
                    reserveLoop = 0;
                    Console.Clear();
                }
            } while (reserveLoop == 1);
        
        }//end Menu
        public void ReserveAddition()
        {
            Console.WriteLine("How much do you want to add to your Reserve");
            addReserveMoney = Console.ReadLine();
            reserveAdd = double.Parse(addReserveMoney);
            reserveTotal = reserveTotal + reserveAdd;
            addReserveMoney = string.Format("{0:C}", reserveAdd);
            recieptReserve = recieptReserve + addReserveMoney + " + " + DateTime.Now + "  " + ReserveCurrency(reserveTotal) + "\n";
            Console.WriteLine(firstName + " " + lastName + "'s Account");
            Console.WriteLine("Account type: Reserve");
            Console.WriteLine(recieptReserve);
            System.Threading.Thread.Sleep(2000);

        }//end RerserveAddition
        public void ReserveSubtraction()
        {
            Console.WriteLine("How much to take out of the Reserve Account?");
            ReserveCurrency(reserveTotal);
            subReserveMoney = Console.ReadLine();
            reserveSub = double.Parse(subReserveMoney);
            subReserveMoney = string.Format("{0:C}", reserveSub);
            if (reserveTotal >= reserveSub)
            {
                reserveTotal = reserveTotal - reserveSub;
                recieptReserve = recieptReserve + subReserveMoney + " - " + DateTime.Now + "  " + ReserveCurrency(reserveTotal) + "\n";
                Console.WriteLine(firstName + " " + lastName + "'s Account");
                Console.WriteLine("Account type: Reserve");
                Console.WriteLine(recieptReserve);
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("You cannot take out that much, sorry");
                System.Threading.Thread.Sleep(2000);
            }
        }//end reserve subtraction
        public string ReserveCurrency(double reserveTotal)
        {
            //formats the account amount to us currency format
            string totalReserve = string.Format("Total in Savings: {0:C}", reserveTotal);
            return totalReserve;
        }//ends ReserveCurrenct
        public void ReserveReciept(string reciept)
        {
            Console.WriteLine(recieptReserve);
            StreamWriter writerReserve = new StreamWriter("..\\..\\ReserveAccountInfo.txt");
            using (writerReserve)
            {
                //write a line
                writerReserve.WriteLine(firstName + " " + lastName);
                writerReserve.WriteLine("Account ID:" + accountID);
                writerReserve.WriteLine("Reserve ID:" + reserveID);
                writerReserve.WriteLine(reciept);
            }
        }//end ReserveReciept
    }//end ReserveAccount
}
