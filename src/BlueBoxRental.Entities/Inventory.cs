using System;
using System.Collections.Generic;

namespace BlueBoxRental.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            Rental = new HashSet<Rental>();
        }

        public int InventoryId { get; set; }
        public int FilmId { get; set; }
        public int StoreId { get; set; }
        public DateTime LastUpdate { get; set; }

        public Film Film { get; set; }
        public Store Store { get; set; }
        public ICollection<Rental> Rental { get; set; }
    }
}
