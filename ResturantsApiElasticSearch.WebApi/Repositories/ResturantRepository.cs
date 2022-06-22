using Nest;
using ResturantsApiElasticSearch.WebApi.Contracts;
using ResturantsApiElasticSearch.WebApi.Indices;

namespace ResturantsApiElasticSearch.WebApi.Repositories
{
    public class ResturantRepository : IResturantRepository
    {
        private readonly IElasticClient _client;
        public ResturantRepository(IElasticClient client)
        {
            _client = client;
        }
        public async Task<ResturantIndex> Delete(ResturantIndex resturantIndex)
        {
            var data = await _client.DeleteAsync<ResturantIndex>(resturantIndex.Id);
            return resturantIndex;
        }
        public async Task<ResturantIndex> Delete(string id)
        {
            var data = await GetById(id);
            return await Delete(data);
        }
        public async Task<ResturantIndex> GetById(string id)
        {
            var data = await _client.SearchAsync<ResturantIndex>(s => s
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
        public async Task<IEnumerable<ResturantIndex>> GetList()
        {
            var data = await _client.SearchAsync<ResturantIndex>(s => s
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
        public async Task<IEnumerable<ResturantIndex>> GetList(string query)
        {
            var data = await _client.SearchAsync<ResturantIndex>(s => s
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
        public async Task<ResturantIndex> Insert(ResturantIndex resturantIndex)
        {
            var data = await _client.CreateDocumentAsync<ResturantIndex>(resturantIndex);
            return resturantIndex;
        }
        public async Task<ResturantIndex> Update(ResturantIndex resturantIndex)
        {
            var data = await _client.UpdateAsync<ResturantIndex>(resturantIndex.Id, i => i.Index(typeof (ResturantIndex)).Doc(resturantIndex));
            return resturantIndex;
        }
    }
}