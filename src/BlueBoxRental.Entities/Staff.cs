using System;
using System.Collections.Generic;

namespace BlueBoxRental.Entities
{
    public partial class Staff
    {
        public Staff()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        public byte StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public int StoreId { get; set; }
        public bool? Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdate { get; set; }

        public Address Address { get; set; }
        public Store Store { get; set; }
        public Store StoreNavigation { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Rental> Rental { get; set; }
    }
}
