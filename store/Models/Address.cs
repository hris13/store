using System;
using System.Collections.Generic;

namespace store.Models
{
    public partial class Address
    {
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? AccountId { get; set; }
        public int AddressId { get; set; }

        public virtual Account? Account { get; set; }
    }
}
