using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.DTO.Auth;

namespace Ecom.Core.Interfaces
{
    public interface IAuth
    {

        public Task<string> RegisterAsync(RegisterDTO registerDTO);
        public Task SendEmail(string email, string code, string subject, string component, string message);
        public Task<string> LoginAsync(LoginDTO loginDTO);
        public Task<bool> SendEmailForForgetPassword(string email);
        public Task<string> ResetPAssword(ResetDTO resetDTO);
        public Task<bool> ActiveAccount(ActiveAccountDTO activeAccountDTO);


    }
}
