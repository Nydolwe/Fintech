using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApiFintech.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public Customers Customers { get; set; }
    }
}
