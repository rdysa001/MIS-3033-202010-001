using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApp
{
    class PokemonNameAPI
    {
        public List<Monster> results { get; set; }
        public info info { get; set; }
    }
    public class Monster
    {

        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
    public class info
    {
        public  sprite sprites { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
    }

    public class sprite
    {
        public string back_default { get; set; }
        public string front_default { get; set; }
    }
}
