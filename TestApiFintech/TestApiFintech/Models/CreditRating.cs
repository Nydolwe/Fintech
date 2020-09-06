using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiFintech.Models
{
    public class CreditRating
    {
        public string Rating { get; set; }
        public string Source { get; set; }
        public NewCustomer NewCustomer { get; set; }
    }
}
