using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankDemo.ResponseModel
{
    public class PaginatedResponseModel<TEntity> where TEntity : class
    {
        public PaginatedResponseModel(int pageSize, int pageIndex, long total, IEnumerable<TEntity> data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Total = total;
            Data = data;
        }

        public int PageSize { get; }
        public int PageIndex { get; }
        public long Total { get; }
        public IEnumerable<TEntity> Data { get; }
    }
}
