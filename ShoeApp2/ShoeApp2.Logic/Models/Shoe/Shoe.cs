using System;
using ShoeApp2.Interface.DTO; 

namespace ShoeApp2.Logic.Models.Shoe
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public Shoe(ShoeDTO shoeDTO)
        {
            this.Id = shoeDTO.Id;
            this.Brand = shoeDTO.Brand;
            this.Name = shoeDTO.Name;
            this.Price = shoeDTO.Price;
            this.Description = shoeDTO.Description;
            this.ImageURL = shoeDTO.ImageURL;            
        }
    }
}
