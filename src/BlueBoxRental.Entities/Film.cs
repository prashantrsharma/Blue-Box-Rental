using System;
using System.Collections.Generic;

namespace BlueBoxRental.Entities
{
    public partial class Film
    {
        public Film()
        {
        }

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public byte LanguageId { get; set; }
        public byte? OriginalLanguageId { get; set; }
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public DateTime LastUpdate { get; set; }
        public Language Language { get; set; }
        public Language OriginalLanguage { get; set; }
    
    }
}
