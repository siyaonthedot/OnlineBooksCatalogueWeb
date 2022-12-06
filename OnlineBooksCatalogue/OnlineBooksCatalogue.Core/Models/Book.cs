using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooksCatalogue.Core.Models
{
    public class Book
    {

        public int BookId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public double PurchasePrice { get; set; }
    }
}
