using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Classes_2
{
    class Toy
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        private string Aisle { get; set; }

        public Toy()
        {
            Manufacturer = Manufacturer;
            Name = Name;
            Price = Price;
            Aisle = "";
        }

        public string GetAisle()
        {
            string aisleGot = Manufacturer[0]+Convert.ToString(Price).Replace(".", "");
            return aisleGot;
        }

        public override string ToString()
        {
            return "{" + Manufacturer + "} - {" + Name + "}";
        }
    }
}
