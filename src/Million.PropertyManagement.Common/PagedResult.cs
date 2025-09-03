namespace Million.PropertyManagement.Common
{
    /// <summary>
    /// Representa un conjunto de resultados paginados para una colección de elementos.
    /// </summary>
    public class PagedResult<T>
    {
        /// <summary>
        /// Obtiene o establece los elementos de la página actual.
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de elementos sin paginar.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Obtiene o establece el número de la página actual (comenzando desde 1).
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Obtiene o establece el tamaño de la página (cantidad de elementos por página).
        /// </summary>
        public int PageSize { get; set; }

        public PagedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

}
