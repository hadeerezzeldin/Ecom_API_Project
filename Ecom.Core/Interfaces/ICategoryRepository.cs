﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.Models;

namespace Ecom.Core.Interfaces
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        //for specific func for category
        //public Task<List<Category>> GetAllCategoryWithProducts();
    }
}
