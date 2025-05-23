using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecom.Core.DTO.Auth;
using Ecom.Core.DTO.Email;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Ecom.Core.Services;
using Ecom.Core.Sharing;
using Ecom.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Infrastructure.Repository
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IEmailService emailService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IGenerateToken token;
        private readonly AppDbContext appContext;   
        public AuthRepository(UserManager<AppUser> userManager, IEmailService emailService, SignInManager<AppUser> signInManager, IGenerateToken token, AppDbContext appContext)
        {
            this.userManager = userManager;
            this.emailService = emailService;
            this.signInManager = signInManager;
            this.token = token;
            this.appContext = appContext;
        }

        //public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        //{
        //    if(registerDTO == null)
        //    {
        //        return null;
        //    }
        //    if(await userManager.FindByNameAsync(registerDTO.UserName) != null)
        //    {
        //        return " This UserName already registered";
        //    }
        //    if(await userManager.FindByEmailAsync(registerDTO.Email) != null)
        //    {
        //        return " This Email already registered";
        //    }
        //    var user = new AppUser
        //    {
        //        UserName = registerDTO.UserName,
        //        Email = registerDTO.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        Address = new Address // ← أضف هذا الجزء
        //        {
        //            FirstName = "",
        //            LastName = "",
        //            ZipCode = "",
        //            City = "",
        //            State = ""
        //        } //
        //    };

        //    var result = await userManager.CreateAsync(user, registerDTO.Password);
        //    if(result.Succeeded is not true)
        //    {
        //        return result.Errors.ToList()[0].Description;
        //    }

        //    // send active email
        //    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        //    await  SendEmail(user.Email , token, "active", "Active Email", "Click Here to Active  your Email");
        //    return "Register Done";
        //}


        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {

            if (registerDTO == null)
                return null;

            if (await userManager.FindByNameAsync(registerDTO.UserName) != null)
                return "This UserName already registered";
            
            if (await userManager.FindByEmailAsync(registerDTO.Email) != null)
                return "This Email already registered";

            //Address xaddress = registerDTO.Address;
            //appContext.Add(xaddress);
            //await appContext.SaveChangesAsync();

            var user = new AppUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                DisplayName = registerDTO.UserName
            };



            var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return result.Errors.ToList()[0].Description;
            }

           

            // Send activation email
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await SendEmail(user.Email, token, "active", "Active Email", "Click Here to Active your Email");

            return "Register Done";
        }


        public async Task  SendEmail( string email ,string code , string subject , string component , string message)
        {
            var result = new EmailDTO(email,
                "hadeerezz511@gmail.com", 
                subject, 
                EmailStringBody.send(email, code, component, message));

              await  emailService.sendEmail(result);
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            if(loginDTO == null)
            {
                return null;
            }
             var findUser = await userManager.FindByEmailAsync(loginDTO.Email);
            //if (!findUser.EmailConfirmed)
            //{
            //    string token = await userManager.GenerateEmailConfirmationTokenAsync(findUser);
            //    await SendEmail(findUser.Email, token, "active", "Active Email", "Click Here to Active  your Email");
            //    return "Please Confirm Your Email First, We have sent an activate email for you"; 
            //}
            var result = signInManager.CheckPasswordSignInAsync(findUser, loginDTO.Password, true);
                 
            if(result.Result.Succeeded)
            {
                return token.GetAndCreateToken(findUser);
            }
            return " Please Check your Email and Password,Something wrong !";


        }

        public async Task<bool> SendEmailForForgetPassword( string email)
        {
            var findUser = await userManager.FindByEmailAsync(email);
            if (findUser == null)
            {
                return false;
            }
            var token = await userManager.GeneratePasswordResetTokenAsync(findUser);
            await SendEmail(findUser.Email, token, "ResetPassword", "Reset Password", "Click Here toReset PAssword");
            return true;    
        }

        public async Task<string> ResetPAssword(ResetDTO resetDTO)
        {
            //if (resetDTO == null)
            //{
            //    return null;
            //}
            var findUser = await userManager.FindByEmailAsync(resetDTO.Email);
            if (findUser == null)
            {
                return "This Email not found";
            }
            var result = await userManager.ResetPasswordAsync(findUser, resetDTO.Token, resetDTO.Password);
            if (result.Succeeded )
            {
            return "Reset Password Done";
            }
                return result.Errors.ToList()[0].Description;

        }
        public async Task<bool> ActiveAccount(ActiveAccountDTO activeAccountDTO)
        {
            var findUser = await userManager.FindByEmailAsync(activeAccountDTO.Email);
            if (findUser == null)
            {
                return false;
            }
            var result = await userManager.ConfirmEmailAsync(findUser, activeAccountDTO.token);
            if (result.Succeeded)
            
                return true;
            
            var token = await userManager.GenerateEmailConfirmationTokenAsync(findUser);
            await SendEmail(findUser.Email, token, "active", "Active Email", "Click Here  to Active Email");
            return false;
        }
    }
}  

