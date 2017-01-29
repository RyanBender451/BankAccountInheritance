using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    //Main Account ID's will be different from savings ID, Reserve ID, and Checking ID
    //This part is barebones because it just passes the information to the child accounts
    class BaseAccount
    {
        //seting up the vars in the base
        protected string firstName;
        protected string lastName;
        protected string accountID;
       

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public string AccountID
        {
            get { return this.accountID; }
            set { this.accountID = value; }
        }
  
        public BaseAccount()
        {
   
        }
        public BaseAccount(string firstName, string lastName, string accountID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.accountID = accountID;
     
        }
       
            

    }
}
