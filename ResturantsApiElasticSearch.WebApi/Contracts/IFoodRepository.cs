using ResturantsApiElasticSearch.WebApi.Indices;

namespace ResturantsApiElasticSearch.WebApi.Contracts
{
    public interface IFoodRepository
    {
        Task<IEnumerable<FoodIndex>> GetList();
        Task<IEnumerable<FoodIndex>> GetList(string query);
        Task<FoodIndex> GetById(string id);
        Task<FoodIndex> Update(FoodIndex foodIndex);
        Task<FoodIndex> Insert(FoodIndex foodIndex);
        Task<FoodIndex> Delete(FoodIndex foodIndex);
        Task<FoodIndex> Delete(string id);
    }
}