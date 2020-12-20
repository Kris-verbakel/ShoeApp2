using System;
using System.Collections.Generic;
using System.Text;
using ShoeApp2.Interface.DTO; 

namespace ShoeApp2.Interface.Interfaces
{
    public interface IShoeDAL
    {
        public ShoeDTO GetShoeByName(string name);
        public ShoeDTO GetShoeById(int id);
        public List<ShoeDTO> GetAllShoes(); 
        public List<ShoeDTO> GetShoesByBrand(string brand); 
    }
}
