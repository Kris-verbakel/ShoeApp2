using ShoeApp2.Interface.Interfaces;
using ShoeApp2.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeApp2.Logic.Models.Shoe
{
    public class ShoeContainer : IShoeContainer
    {
        private readonly IShoeDAL _shoeDAL; 
        
        public ShoeContainer(IShoeDAL shoeDAL)
        {
            _shoeDAL = shoeDAL; 
        }

        public Shoe GetShoeByID(int id)
        {
            var shoeDTO = _shoeDAL.GetShoeById(id);
            return new Shoe(shoeDTO); 
        }

        public Shoe GetShoeByName(string name)
        {
            var shoeDTO = _shoeDAL.GetShoeByName(name);
            return new Shoe(shoeDTO); 
        }

        public List<Shoe> GetAllShoes()
        {
            var shoeDTOs = _shoeDAL.GetAllShoes();
            List<Shoe> shoes = new List<Shoe>(); 
            
            foreach(var shoeDTO in shoeDTOs)
            {
                shoes.Add(new Shoe(shoeDTO)); 
            }
            return shoes; 
        }

        public List<Shoe> GetShoesByBrand(string brand)
        {
            var shoeDTOs = _shoeDAL.GetShoesByBrand(brand);
            List<Shoe> shoes = new List<Shoe>(); 

            foreach (var shoeDTO in shoeDTOs)
            {
                shoes.Add(new Shoe(shoeDTO));
            }
            return shoes;
        }
    }
}
