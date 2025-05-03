using Microsoft.EntityFrameworkCore;

namespace Employee.Helper.Pagination
{
    public static class PagingHelper
    {
        public static async Task<PagingResponse<T>> CreatePagingAsync<T>(this IQueryable<T> query, int pageIndex = 1, int pageSize = 2)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            if (pageSize <= 0)
            {
                pageSize = 100;
            }
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }

            int records = await query.CountAsync();

            int totalPages = (int)Math.Ceiling((double)records / pageSize);

            if (records == 0)
            {
                return new PagingResponse<T>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Items = new List<T>(),
                    Records = records,
                    Pages = totalPages
                };
            }

            pageIndex = Math.Min(pageIndex, totalPages);

            int excludedRows = (pageIndex - 1) * pageSize;

            var items = await query.Skip(excludedRows)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PagingResponse<T>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = items,
                Records = records,
                Pages = totalPages
            };
        }


    }
}
