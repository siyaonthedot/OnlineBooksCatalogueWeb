using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooksCatalogue.Core.Models
{
    public class Subscription
    {

        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public int? BookId { get; set; }
       // public Book Books { get; set; }
        public int? UserId { get; set; }
       // public User Users { get; set; }
    }
}
