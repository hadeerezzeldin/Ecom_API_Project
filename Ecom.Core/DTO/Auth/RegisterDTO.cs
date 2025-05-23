using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Models;

namespace Ecom.Core.DTO.Auth
{
    public record RegisterDTO
    {
        public string UserName{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public Address Address { get; set; }

    }
}
