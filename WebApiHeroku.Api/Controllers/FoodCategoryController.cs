using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiHeroku.Core.Entities;

namespace WebApiHeroku.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class FoodCategoryController: ControllerBase
    {
         [HttpGet]
        public IEnumerable<Category> Get()
        {
           var categories = new List<Category>{
               new Category("Comida Brasileira"),
               new Category("Comida Mexicana"),
               new Category("Comida Asiática"),
               new Category("Comida Italiana"),
               new Category("Comida Alemã"),
               new Category("Lanches Rápidos"),
               new Category("Comida Vegana"),
           };
           
           return categories;
        }
    }
}