﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooksCatalogue.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; } 

        public string EmailAddress { get; set; }
            
    }
}
