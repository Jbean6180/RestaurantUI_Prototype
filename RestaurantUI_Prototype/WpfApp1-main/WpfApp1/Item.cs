using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Item
    {
        public string Name { get; set; }
        public float Cost { get; set; }

        public Item(string name, float cost)
        {
            Name = name;
            Cost = cost; 
        }
    }
}
