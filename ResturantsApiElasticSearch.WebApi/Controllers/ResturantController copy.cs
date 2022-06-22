using Microsoft.AspNetCore.Mvc;
using ResturantsApiElasticSearch.WebApi.Contracts;
using ResturantsApiElasticSearch.WebApi.Indices;

namespace ResturantsApiElasticSearch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private IFoodRepository _food;
        public FoodController(IFoodRepository food)
        {
            _food = food;
        }

        /// <summary>
        /// دریافت لیست کلیه غذاها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllFood")]
        public async Task<List<FoodIndex>> Get()
        {
            var data = await _food.GetList();
            return data.ToList();
        }
        /// <summary>
        /// دریافت لیست غذا ها توسط کویری دلخواه
        /// </summary>
        /// <param name="query">کویری دلخواه</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFoodsByQuery")]
        public async Task<List<FoodIndex>> Get([FromBody] string query)
        {
            var data = await _food.GetList(query);
            return data.ToList();
        }


        /// <summary>
        /// دریافت اطلاعات غذا بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه غذا</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFoodById")]
        public async Task<FoodIndex> GetById([FromForm] string id)
        {
            var data = await _food.GetById(id);
            return data;
        }

        [HttpPost]
        [Route("InsertFood")]
        public async Task<FoodIndex> Insert([FromBody]  FoodIndex foodIndex)
        {
            var data = await _food.Insert(foodIndex);
            return data;
        }

        /// <summary>
        /// حدف یک داکیومنت خاص بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه غذا</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteFoodById")]
        public async Task<FoodIndex> DeleteById([FromForm] string id)
        {
            var data = await _food.Delete(id);
            return data;
        }
        /// <summary>
        /// آپدیت یک داکومنت بر اساس مدل آن
        /// </summary>
        /// <param name="foodIndex"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateFood")]
        public async Task<FoodIndex> Update([FromBody]  FoodIndex foodIndex)
        {
            var data = await _food.Update(foodIndex);
            return data;
        }


    }
}