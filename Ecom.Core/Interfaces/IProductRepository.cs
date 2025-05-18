using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Core.DTO.Product;
using Ecom.Core.Models;
using Ecom.Core.Sharing;

namespace Ecom.Core.Interfaces
{
    public interface IProductRepository :IGenericRepository<Product>
    {

        //specific func for prod
        Task<IEnumerable<ProductDTO>> GetAllAsync(ProductParams productParams);
        Task<bool> AddAsync(AddProductDTO productDTO);
        Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task DeleteAsync(Product product);
    }
}
