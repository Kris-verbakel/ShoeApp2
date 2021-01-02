using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoeApp2.Logic;
using ShoeApp2.Logic.Models.Shoe;

namespace ShoeApp2.ViewModels.ShoeViewModels
{
    public class ShoeViewModel
    {
        public int Id { get; set; }
        public string Brand  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }

        public ShoeViewModel(Shoe shoe)
        {
            this.Id = shoe.Id;
            this.Brand = shoe.Brand;
            this.Name = shoe.Name;
            this.Price = shoe.Price;
            this.Description = shoe.Description;
            this.ImageURL = shoe.ImageURL; 
        }
    }
}
