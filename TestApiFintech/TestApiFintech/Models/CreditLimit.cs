using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiFintech.Models
{
    public class CreditLimit
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public NewCustomer NewCustomer { get; set; }
    }
}
