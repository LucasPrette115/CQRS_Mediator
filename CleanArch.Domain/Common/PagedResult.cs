namespace CleanArch.Domain.Common
{
    public class PagedResult<T>(int pageNumber, int pageSize, int totalRecords, bool? nonPaged, List<T> items)
    {
        public int PageNumber { get; private set; } = pageNumber;
        public int PageSize { get; private set; } = pageSize;
        public int TotalRecords { get; private set; } = totalRecords;
        public bool NonPaged { get; private set; } = nonPaged ?? false;
        public int TotalPages { get; private set; } = (int)Math.Ceiling((double)totalRecords / pageSize);
        public List<T> Result { get; private set; } = items ?? [];
    }
}
