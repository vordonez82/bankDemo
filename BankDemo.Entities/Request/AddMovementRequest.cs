using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Entities.Request
{
    public class AddMovementRequest
    {
        public decimal Amount { get; set; }
        public string Concept { get; set; }
        public int AccountId { get; set; }
    }
}
