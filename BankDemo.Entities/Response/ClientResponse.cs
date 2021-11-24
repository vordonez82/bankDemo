using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Entities.Response
{
    public class ClientResponse
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
