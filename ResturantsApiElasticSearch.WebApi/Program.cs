using System.Reflection;
using Microsoft.OpenApi.Models;
using ResturantsApiElasticSearch.WebApi.Contracts;
using ResturantsApiElasticSearch.WebApi.Extentions;
using ResturantsApiElasticSearch.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ElasticSearch Api",
        Version = "v1",
        Description = "An API to Show RestaurantIndex an FoodIndex"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IResturantRepository, ResturantRepository>();
builder.Services.AddScoped<IFoodRepository, FoodsRepository>();
builder.Services.AddElasticsearch(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    //options.InjectStylesheet("/css/site.css");  
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
