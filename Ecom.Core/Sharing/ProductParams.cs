using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Sharing
{
    public class ProductParams
    {
        //int? categoryId,int pageNumber, int pageSize, [FromQuery] string? sort = null
        public  string? sort { get; set; }
        public int? categoryId { get; set; }
        public string? Search { get; set; }

        public int MaxPageSize { get; set; } = 6;
        private int _pageSize { get; set; } = 3;
        public int pageSize
        {
            get { return _pageSize; }
            //set { _pageSize  = value > MaxPageSize ? MaxPageSize : _pageSize = value; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public int pageNumber { get; set; } = 1;
    }
}
