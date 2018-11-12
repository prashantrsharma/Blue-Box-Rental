using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBoxRental.Entities.Extended
{
    public class RentalViewModel
    {
        public RentalViewModel()
        {
            Payment = new HashSet<Payment>();
        }

        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public byte StaffId { get; set; }
        public DateTime LastUpdate { get; set; }
        public Customer Customer { get; set; }
        public Inventory Inventory { get; set; }
        public Staff Staff { get; set; }
        public int FilmId { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public IList<Staff> ListStaffs { get; set; }
        public IList<Customer> ListCustomers { get; set; }
        public IList<Film> ListFilms { get; set; }
    }
}
