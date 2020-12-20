using ShoeApp2.Logic.Models.Shoe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeApp2.Logic.Interfaces
{
    public interface IShoeContainer
    {
        public Shoe GetShoeByID(int id);
        public Shoe GetShoeByName(string name);
        public List<Shoe> GetAllShoes();
        public List<Shoe> GetShoesByBrand(string brand);     
    }
}
