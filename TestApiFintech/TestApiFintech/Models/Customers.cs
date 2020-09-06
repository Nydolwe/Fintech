using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiFintech.Models
{
    public class Customers
    {
        public Customers()
        {
            Owners = new HashSet<Owner>();
            Balances = new HashSet<Balance>();
            AccountRoutings = new HashSet<AccountRoutings>();
        }

        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public string BankId { get; set; }
        public string Label { get; set; }
        public long Number { get; set; }
        public string Type { get; set; }
        public ICollection<Owner> Owners { get; set; }
        public ICollection<Balance> Balances { get; set; }
        public ICollection<AccountRoutings> AccountRoutings { get; set; }
    }
}
