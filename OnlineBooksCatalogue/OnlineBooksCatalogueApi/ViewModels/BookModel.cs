using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OnlineBooksCatalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineBooksCatalogueApi.ViewModels
{
    public class BookModel
    {
        public int BookId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public double PurchasePrice { get; set; }
    }

    public class UserMode
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }

    }

    public class SubscriptionModel
    {

        public int SubscriptionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int BookId { get; set; }
       // [Required]
       // public Book Books { get; set; }
        public int UserId { get; set; }
        //[Required]
        //public User Users { get; set; }
    }

}



