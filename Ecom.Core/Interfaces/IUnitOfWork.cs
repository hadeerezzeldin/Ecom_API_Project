﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository categoryRepository { get; }
        public IProductRepository productRepository { get; }
        public IPhotoRepository photoRepository { get; }
        public ICartReository cartReository { get; }
    }
}
