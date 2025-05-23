using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Models;

namespace Ecom.Core.Services
{
    public interface IGenerateToken
    {
      string GetAndCreateToken(AppUser appUser);
    }
}
