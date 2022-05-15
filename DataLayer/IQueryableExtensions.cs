namespace DataLayer
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int itemsPerPage)
        {
            return source
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage);
        }
    }
}
