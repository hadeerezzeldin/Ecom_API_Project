using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        //public Address? Address { get; set; }
    }
   
}
