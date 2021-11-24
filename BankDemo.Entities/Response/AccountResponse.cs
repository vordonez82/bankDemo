using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Entities.Response
{
    public class AccountResponse
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string Status { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountType { get; set; }

        public int ClientId { get; set; }
    }
}
