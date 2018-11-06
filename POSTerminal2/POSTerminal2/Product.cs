using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal2
{ 
    class Product
    {
        private static int _counter = 1;
        protected int _listnum;
        protected string _name;
        protected string _category;
        protected string _description;
        protected double _price;
        protected int _quantity;

        public Product(string Name, string Category, string Description, double Price)
        {
            _listnum = _counter++;
            _name = Name;
            _category = Category;
            _description = Description;
            _price = Price;
            _quantity = 1;
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

        public void SetQuantity(int input)
        {
            _quantity = input;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
