using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Model
{
    public class SPView
    {
        public int supplier_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public int feedback { get; set; }

        public int id { get; set; }
        public int partid { get; set; }
        public string partname { get; set; }
        public int quantity { get; set; }
        public int timeperiod { get; set; }
        
        public int sid { get; set; }


    }
}
