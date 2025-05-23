using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.DTO.Email;

namespace Ecom.Core.Services
{
    public interface IEmailService
    {

        Task sendEmail(EmailDTO emailDTO);  
    }
}
