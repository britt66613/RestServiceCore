using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [Route("~/api/GetAllObject/{includes}")]
        [HttpGet]
        public IEnumerable<Restaurant> GetAllObject(string includes = null)
        {
            var result = _restaurantService.GetAll(new[] { "Menu", "Location", "FoodMenus" }).ToList();
            return result;
        }

        // POST api/values
        [Route("~/api/AddRestaurant")]
        [HttpPost]
        public void Post([FromBody]Restaurant restaurant)
        {
            _restaurantService.Create(restaurant);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
