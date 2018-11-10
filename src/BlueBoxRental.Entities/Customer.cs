using System;
using System.Collections.Generic;

namespace BlueBoxRental.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public string Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public Address Address { get; set; }
        public Store Store { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Rental> Rental { get; set; }
    }
}
