using Microsoft.AspNetCore.Mvc;
using ResturantsApiElasticSearch.WebApi.Contracts;
using ResturantsApiElasticSearch.WebApi.Indices;

namespace ResturantsApiElasticSearch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private IResturantRepository _resturant;
        public ResturantController(IResturantRepository resturant)
        {
            _resturant = resturant;
        }

        /// <summary>
        /// دریافت لیست کلیه رستوران
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllResturant")]
        public async Task<List<ResturantIndex>> Get()
        {
            var data = await _resturant.GetList();
            return data.ToList();
        }
        /// <summary>
        /// دریافت لیست رستوران ها توسط کویری دلخواه
        /// </summary>
        /// <param name="query">کویری دلخواه</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetResturantsByQuery")]
        public async Task<List<ResturantIndex>> Get([FromBody] string query)
        {
            var data = await _resturant.GetList(query);
            return data.ToList();
        }


        /// <summary>
        /// دریافت اطلاعات رستوران بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه رستوران</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetResturantById")]
        public async Task<ResturantIndex> GetById([FromForm] string id)
        {
            var data = await _resturant.GetById(id);
            return data;
        }

        [HttpPost]
        [Route("InsertResturant")]
        public async Task<ResturantIndex> Insert([FromBody]  ResturantIndex resturantIndex)
        {
            var data = await _resturant.Insert(resturantIndex);
            return data;
        }

        /// <summary>
        /// حدف یک داکیومنت خاص بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه رستوران</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteResturantById")]
        public async Task<ResturantIndex> DeleteById([FromForm] string id)
        {
            var data = await _resturant.Delete(id);
            return data;
        }
        /// <summary>
        /// آپدیت یک داکومنت بر اساس مدل آن
        /// </summary>
        /// <param name="resturantIndex"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateResturant")]
        public async Task<ResturantIndex> Update([FromBody]  ResturantIndex resturantIndex)
        {
            var data = await _resturant.Update(resturantIndex);
            return data;
        }


    }
}