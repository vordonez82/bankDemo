using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Entities.Request
{
    public class AddAccountRequest
    {
        public string AccountNumber { get; set; }
        public string Status { get; set; }
        public string AccountType { get; set; }

        public int ClientId { get; set; }
    }
}
