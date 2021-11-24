using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Entities.Response
{
    public class MovementResponse
    {
        public int MovementId { get; set; }
        public decimal Amount { get; set; }
        public int MovementType { get; set; }
        public string Concept { get; set; }

        public DateTime OperationDate { get; set; }

        public int AccountId { get; set; }
    }
}
