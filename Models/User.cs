using System;
using System.Collections.Generic;
using Bank_Account.Models;

namespace Bank_Account.Models
{
    //public abstract class BaseEntity {}
    public class User 
    {
        public User()
        {
            Transactions = new List<Transaction>();
        }
        public int userid { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int amount { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}

