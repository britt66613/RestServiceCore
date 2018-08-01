using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS.API.Model;
using RS.Entities.Entity;
using RS.Services.Interfaces;
using RS.Services.Services;

namespace RS.API.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService<Restaurant> _restaurantService;

        public RestaurantController(IRestaurantService<Restaurant> restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Restaurant Get(Guid id)
        {
            return _restaurantService.GetByKey(id);
        }

        //http://localhost:53399/api/restaurant/GetAll?includes=Location&includes=Action
        [Route("GetAll")]
        [HttpPost]
        public IEnumerable<Restaurant> GetAll(string [] includes)
        {

            var result = _restaurantService.GetAll(includes);
            return result;
        }

        //[Route("Filter")]
        //[HttpPost]
        //public IEnumerable<Restaurant> Filter([FromBody] FilterModel model)
        //{
        //    var result = _restaurantService.Filter(model);
        //    return result;
        //}

        // POST api/values
        [Route("~/api/AddRestaurant")]
        [HttpPost]
        public void Post([FromBody]Restaurant restaurant)
        {
            _restaurantService.Create(restaurant);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Restaurant restaurant)
        {
            if(ModelState.IsValid)
            _restaurantService.Update(restaurant);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _restaurantService.Delete(id);
        }
    }
}
