using System.ComponentModel.DataAnnotations;

namespace OnlineBooksCatalogue.Models
{
    public class UserInfo
    {
       [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}
