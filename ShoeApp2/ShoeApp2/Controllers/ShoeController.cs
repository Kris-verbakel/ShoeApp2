using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeApp2.ViewModels;
using ShoeApp2.Data; 
using ShoeApp2.ViewModels.ShoeViewModels;
using ShoeApp2.Logic.Interfaces;

namespace ShoeApp2.Controllers
{
    public class ShoeController : Controller
    {
        private readonly IShoeContainer _shoeContainer;

        public ShoeController(IShoeContainer shoeContainer)
        {
            _shoeContainer = shoeContainer; 
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: Shoe/ListShoe
        public IActionResult ListShoe()
        {
            var result = _shoeContainer.GetAllShoes(); 
            var shoes = new List<ShoeViewModel>();

            foreach(var shoe in result)
            {
                var model = new ShoeViewModel(shoe);
                shoes.Add(model); 
            }
            return View(shoes); 
        }

        public IActionResult ListShoeByBrand(string brand)
        {
            var result = _shoeContainer.GetShoesByBrand(brand);
            var shoes = new List<ShoeViewModel>();

            foreach (var shoe in result)
            {
                var model = new ShoeViewModel(shoe);
                shoes.Add(model);
            }
            return View("ListShoe", shoes);
        }
    }
}
