using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Entities.Request
{
    public class EditAccountRequest
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string Status { get; set; }
        public string AccountType { get; set; }
      
    }
}
