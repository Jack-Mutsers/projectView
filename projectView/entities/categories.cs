using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectView.entities
{
    class Categories
    {
        private int _id;
        private string _name;

        public int id { get; set; }
        public string name { get; set; }

        public IEnumerable<Components> Components { get; set; }
    }
}
