using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooksCatalogue.Core.Models
{
    public class Catalogue
    {
        public int CatalogueId { get; set; }
        public string Name { get; set; }
        public Book Books { get; set; }


    }
}
