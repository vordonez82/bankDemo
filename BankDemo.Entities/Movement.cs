using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Entities
{
    public class Movement
    {
        public int MovementId { get; set; }
        public decimal Amount { get; set; }
        public int MovementType { get; set; }
        public string Concept { get; set; }

        public DateTime OperationDate { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
