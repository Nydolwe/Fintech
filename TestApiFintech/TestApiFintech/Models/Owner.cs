using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApiFintech.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Provider { get; set; }
        public string DisplayName { get; set; }
        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public Customers Customers { get; set; }
    }
}
