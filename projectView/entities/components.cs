using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace projectView.entities
{
    class Components
    {
        private int _id;
        private string _name;
        private int _categoryid;
        private bool _status;

        public int id { get; set; }
        public string name { get; set; }
        public int categoryid { get; set; }
        public bool status { get; set; }

        public string btnState
        {
            get { return status ? "close" : "open"; }
        }

        public Brush stateBackGround
        {
            get { return status? Brushes.Red : Brushes.Green; }
        }

        public string stateText
        {
            get { return status ? "open" : "close"; }
        }
    }
}
