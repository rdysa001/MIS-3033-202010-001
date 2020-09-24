using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace JSON___RickAndMorty
{
    class RickAndMortyAPI
    {
        public info info { get; set; }

        public List<Character> results { get; set; }


    }

    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class info
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string next { get; set; }
        public string prev { get; set; }
    }
}
