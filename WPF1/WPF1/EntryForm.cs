using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF1
{
    class EntryForm
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }

        public EntryForm()
        {
            Name = null;
            Address = null;
            ZipCode = 0;
        }

        public EntryForm(string name, string address, int zipCode)
        {
            Name = name;
            Address = address;
            ZipCode = zipCode;
        }
        public override string ToString()
        {
            return "NAME: "+ Name+" ADDRESS: "+Address+" ZIP CODE: "+ZipCode;
        }

    }
}
