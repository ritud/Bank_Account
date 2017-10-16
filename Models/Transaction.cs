using System;
using System.ComponentModel.DataAnnotations;
//using Bank_Account.Models;

namespace Bank_Account.Models 
{
    public class Transaction
    {
        [Key]
        public int transactionsid { get; set; }
        public int userid { get; set; }
        public User User { get; set; }
        public int amount { get; set; }
        public DateTime transaction_date { get; set; }
    
    }
}