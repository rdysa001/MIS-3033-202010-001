using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P__Classes_3
{
    class Address
    {
        //Address Constructors.
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }

        //Default constructor.
        public Address()
        {
            StreetNumber = 0;
            StreetName = null;
            State = null;
            City = null;
            Zipcode = 0;
        }

        //Overloaded Constructor.
        public Address(int streetnumber, string streetname, string state, string city, int zipcode)
        {
            StreetNumber = streetnumber;
            StreetName = streetname;
            State = state;
            City = city;
            Zipcode = zipcode;
        }
    }
}