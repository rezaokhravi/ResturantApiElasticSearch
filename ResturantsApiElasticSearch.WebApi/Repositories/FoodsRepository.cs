using Nest;
using ResturantsApiElasticSearch.WebApi.Contracts;
using ResturantsApiElasticSearch.WebApi.Indices;

namespace ResturantsApiElasticSearch.WebApi.Repositories
{
    public class FoodsRepository : IFoodRepository
    {
        private readonly IElasticClient _client;
        public FoodsRepository(IElasticClient client)
        {
            _client = client;
        }
        public async Task<FoodIndex> Delete(FoodIndex foodIndex)
        {
            var data = await _client.DeleteAsync<FoodIndex>(foodIndex.Id);
            return foodIndex;
        }
        public async Task<FoodIndex> Delete(string id)
        {
            var data = await GetById(id);
            return await Delete(data);
        }
        public async Task<FoodIndex> GetById(string id)
        {
            var data = await _client.SearchAsync<FoodIndex>(s => s
              .Query(q => q
                  .Term(t => t
                  .Field("_id")
                  .Value(id)
                  )
              )
           );

            return data.Hits.Select(h =>
            {
                h.Source.Id = h.Id;
                return h.Source;
            }).SingleOrDefault();
        }
        public async Task<IEnumerable<FoodIndex>> GetList()
        {
            var data = await _client.SearchAsync<FoodIndex>(s => s
                .Query(q => q
                 .MatchAll()
                )
             );
            return data.Hits.Select(h =>
            {
                h.Source.Id = h.Id;
                return h.Source;
            }).ToList();
        }
        public async Task<IEnumerable<FoodIndex>> GetList(string query)
        {
            var data = await _client.SearchAsync<FoodIndex>(s => s
                .Query(q => q
                 .QueryString(qs => qs.Query(query))
                )
             );
            return data.Hits.Select(h =>
            {
                h.Source.Id = h.Id;
                return h.Source;
            }).ToList();
        }
        public async Task<FoodIndex> Insert(FoodIndex foodIndex)
        {
            var data = await _client.CreateDocumentAsync<FoodIndex>(foodIndex);
            return foodIndex;
        }
        public async Task<FoodIndex> Update(FoodIndex foodIndex)
        {
            var data = await _client.UpdateAsync<FoodIndex>(foodIndex.Id, i => i.Index(typeof (FoodIndex)).Doc(foodIndex));
            return foodIndex;
        }
    }
}