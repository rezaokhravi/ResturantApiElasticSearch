using Nest;

namespace ResturantsApiElasticSearch.WebApi.Indices
{
    [ElasticsearchType(RelationName = "resturants", IdProperty = nameof(Id))]
    public partial class ResturantIndex
    {
        [Keyword(Name = "_id")]
        public string? Id { get; set; }
        [Text(Name = "title")]
        public string Title { get; set; }
        [Keyword(Name = "phone")]
        public string Phone { get; set; }
        [Keyword(Name ="mobile")]
        public string Mobile { get; set; }
        [Text(Name ="address")]
        public string Address { get; set; }
        [Text(Name ="description")]
        public string Description { get; set; }

    }
}