using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeApp2.ViewModels;
using ShoeApp2.Data; 
using ShoeApp2.ViewModels.ShoeViewModels;

namespace ShoeApp2.Controllers
{
    public class ShoeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListShoe()
        {
           //var shoe = new ShoeViewModel { Brand = "Nike", Name = "AF1", Price = 99.99, Description = "White SHoe" };
           //var shoe2 = new ShoeViewModel { Brand = "Adidas", Name = "Superstar", Price = 79.99, Description = null };
       
            var shoes = new List<ShoeViewModel>();

           // shoes.Add(shoe);
           // shoes.Add(shoe2); 

            return View(shoes); 
        }
    }
}
