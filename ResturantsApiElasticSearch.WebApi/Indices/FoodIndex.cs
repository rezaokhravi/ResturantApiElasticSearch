using Nest;

namespace ResturantsApiElasticSearch.WebApi.Indices
{
    [ElasticsearchType(RelationName = "foods", IdProperty = nameof(Id))]
    public partial class FoodIndex
    {
        [Keyword(Name = "_id")]
        public string? Id { get; set; }
        [Keyword(Name = "res_id")]
        public string ResId { get; set; }
        [Text(Name = "title")]
        public string Title { get; set; }
        [Number(Name = "price")]
        public int Price { get; set; }
        [Text(Name = "description")]
        public string Description { get; set; }
    }
}