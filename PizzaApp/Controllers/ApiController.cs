using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Data;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private DataContext dataContext;
        public ApiController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("getPizzas")]
        public IActionResult GetPizzas()
        {
            // var pizza = new Pizza() {Name = "pizza test", Price = 8, Vegetarian = false, Ingredients = "tomatoes, onions, beef, pepperoni"};
            var pizzas = dataContext.Pizzas.ToList();
            
            return Json(pizzas);
        }
    }
}
