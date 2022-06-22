using Nest;
using ResturantsApiElasticSearch.WebApi.Indices;

namespace ResturantsApiElasticSearch.WebApi.Extentions;
public static class ElasticsearchExtensions
{
    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new ConnectionSettings(new Uri(configuration["ElasticsearchSettings:url"]));
       // var defaultIndex = configuration["ElasticsearchSettings:defaultIndex"];
        //if (!string.IsNullOrEmpty(defaultIndex))
            settings = 
            settings
            .DefaultMappingFor<ResturantIndex>(r=> r
            .IndexName("resturants")
            .PropertyName(r =>r.Id , "id")
            )
            .DefaultMappingFor<FoodIndex>(r=>r
            .IndexName("foods")
            .PropertyName(f =>f.Id , "id")
            );
        var client = new ElasticClient(settings);
        services.AddSingleton<IElasticClient>(client);
    }
}
