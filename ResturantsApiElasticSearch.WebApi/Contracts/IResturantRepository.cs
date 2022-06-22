using ResturantsApiElasticSearch.WebApi.Indices;

namespace ResturantsApiElasticSearch.WebApi.Contracts
{
    public interface IResturantRepository
    {
        Task<IEnumerable<ResturantIndex>> GetList();
        Task<IEnumerable<ResturantIndex>> GetList(string query);
        Task<ResturantIndex> GetById(string id);
        Task<ResturantIndex> Update(ResturantIndex resturantIndex);
        Task<ResturantIndex> Insert(ResturantIndex resturantIndex);
        Task<ResturantIndex> Delete(ResturantIndex resturantIndex);
        Task<ResturantIndex> Delete(string id);
    }
}