using System;
using System.Collections.Generic;

namespace BlueBoxRental.Entities
{
    public partial class FilmActor
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }
        public DateTime LastUpdate { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }
}
