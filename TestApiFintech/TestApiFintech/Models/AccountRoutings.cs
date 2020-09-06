using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApiFintech.Models
{
    public class AccountRoutings
    {
        public int Id { get; set; }
        public string Schema { get; set; }
        public string Address { get; set; }
        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public Customers Customers { get; set; }
    }
}
