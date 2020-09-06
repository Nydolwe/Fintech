using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiFintech.Models
{
    public class NewCustomer
    {
        public NewCustomer()
        {
            CreditRatings = new HashSet<CreditRating>();
            CreditLimits = new HashSet<CreditLimit>();
        }
        public string BankId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string RelationStatus { get; set; }
        public string HighestEducation { get; set; }
        public string EmploymentStatus { get; set; }
        public ICollection<CreditRating> CreditRatings { get; set; }
        public ICollection<CreditLimit> CreditLimits { get; set; }
    }
}
