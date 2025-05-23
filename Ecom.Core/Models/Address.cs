using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Core.Models
{
    public class Address
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //public string AppUserId { get; set; }
        //[ForeignKey("AppUserId")]
        //public virtual AppUser appUser { get; set; }
    }
}