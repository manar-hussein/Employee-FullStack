namespace Employee.Helper.Pagination
{
    public class PagingResponse<T>
    {
        public IEnumerable<T> Items { set; get; } = Enumerable.Empty<T>();
        public int Records { set; get; }
        public int Pages { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }

    }
}
