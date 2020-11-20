using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFace
{
    class Test
    {
        string name { get; set; }
        string lat { get; set; }
        string lon { get; set; }
    
        public Test(string name, string lat, string lon)
        {
            this.name = name;
            this.lat = lat;          
            this.lon = lon;
              
        }
        public string ShowCity()
        {
            return name + "\n" + lat + ", " + lon + "\n" ;
        }
        public override string ToString()
        {
            if (name.Contains('"'))
            {
                return name.Trim('"');
            }
            return name;
        }
    }
}
