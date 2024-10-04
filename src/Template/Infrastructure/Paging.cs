using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Template.Infrastructure
{
    public class Paging
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public bool OrderByDescending { get; set; }
        public bool OneMoreItem { get; set; }
        public Paging()
        {
            Page = 1;
            PageSize = 128;
        }
    }

    public static class DocumentQueryPagingExtension
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, Paging paging)
        {
            if (paging == null || string.IsNullOrWhiteSpace(paging.OrderBy))
            {
                return query;
            }
            else
            {
                // Utilizzo di DynamicQueryableExtensions per l'ordinamento dinamico
                if (paging.OrderByDescending)
                {
                    query = DynamicQueryableExtensions.OrderBy(query, paging.OrderBy + " DESC");
                }
                else
                {
                    query = DynamicQueryableExtensions.OrderBy(query, paging.OrderBy);
                }

                if (paging.OneMoreItem)
                {
                    return query.Skip((paging.Page - 1) * paging.PageSize).Take(paging.PageSize + 1);
                }
                else
                {
                    return query.Skip((paging.Page - 1) * paging.PageSize).Take(paging.PageSize);
                }
            }
        }

        public static IQueryable<T> ApplyOrder<T>(this IQueryable<T> query, Paging paging)
        {
            if (paging == null || string.IsNullOrWhiteSpace(paging.OrderBy))
            {
                return query;
            }
            else
            {
                // Utilizzo di DynamicQueryableExtensions per l'ordinamento dinamico
                if (paging.OrderByDescending)
                {
                    return DynamicQueryableExtensions.OrderBy(query, paging.OrderBy + " DESC");
                }
                else
                {
                    return DynamicQueryableExtensions.OrderBy(query, paging.OrderBy);
                }
            }
        }
    }
}