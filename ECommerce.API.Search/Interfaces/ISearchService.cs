namespace ECommerce.API.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool isSuccess, dynamic SearchResult)>SearchAsync(int CusomerId);
    }
}
