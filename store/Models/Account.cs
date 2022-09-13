using System;
using System.Collections.Generic;

namespace store.Models
{
    public partial class Account
    {
        public Account()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int AccountId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
