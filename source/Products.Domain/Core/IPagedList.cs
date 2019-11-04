namespace Products.Domain.Core
{
    public interface IPagedList<T>
    {
        int CurrentPage { get; }
        int PageSize { get; }
        long TotalPages { get; }
        long TotalRecords { get; }

        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}