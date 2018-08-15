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
    public class RestaurantController : ControllerBase
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
        //[HttpGet]
        //public Restaurant Get(Guid id)
        //{
        //    return _restaurantService.GetByKey(id);
        //}

        //http://localhost:53399/api/restaurant/GetAll?includes=Location&includes=Action
        [Route("GetAll")]
        [HttpPost]
        public IEnumerable<Restaurant> GetAll([FromBody] GetModel model)
        {

            var result = _restaurantService.All(model.includes);
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
        public ActionResult Post([FromBody]Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                var result = _restaurantService.Create(restaurant);
                return Ok();
            }
            else return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Restaurant restaurant)
        {
            if(ModelState.IsValid)
            _restaurantService.Update(restaurant);
        }

        // DELETE api/values/5
        [Route("Delete")]
        [HttpPost]
        public void Delete([FromBody] string id)
        {
            _restaurantService.Delete(Guid.Parse(id));
        }
    }
}
