using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Ecom.Core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace Ecom.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IImageManagmentService imageManagmentService;
        private readonly UserManager<AppUser> userManager;
        private readonly IEmailService emailService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IGenerateToken token;

        public ICategoryRepository categoryRepository { get; }

        public IProductRepository productRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public ICartReository cartReository { get; }

        public IAuth Auth { get; }

        public UnitOfWork(AppDbContext context, IImageManagmentService imageManagmentService, IMapper mapper, UserManager<AppUser> userManager, IEmailService emailService, SignInManager<AppUser> signInManager, IGenerateToken token)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.emailService = emailService;
            this.signInManager = signInManager;

            this.token = token;
            categoryRepository = new CategoryRepository(context);
            productRepository = new ProductRepository(context, mapper, imageManagmentService);
            photoRepository = new PhotoRepository(context);
            this.imageManagmentService = imageManagmentService;
            cartReository = new FakeCartRepository();
            Auth = new AuthRepository(userManager, emailService, signInManager, token, context);
        }
    }
}
