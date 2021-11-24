using BankDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemo.Data
{
    public class BankDemoContext : DbContext
    {
        public BankDemoContext(DbContextOptions<BankDemoContext> options): base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movement> Movements { get; set; }
    }
}
