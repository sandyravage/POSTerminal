using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2
{ 
    class Product
    {
        private static int counter = 1;
        protected int _listnum;
        protected string _name;
        protected string _category;
        protected string _description;
        protected double _price;

        public Product(string Name, string Category, string Description, double Price)
        {
            _listnum = counter++;
            _name = Name;
            _category = Category;
            _description = Description;
            _price = Price;
        }

        public override string ToString()
        {
            return $"{_listnum}: {_name} " +
                $"\n   Genre: {_category} " +
                $"\n   Description: {_description} " +
                $"\n   Price: ${_price}";
        }

        public int GetItemID()
        {
            return _listnum;
        }

        public double GetPrice()
        {
            return _price;
        }
    }
}
