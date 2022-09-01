using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupplierMicroservice
{
    public class Supplier_data
    {
        public Supplier_data()
        {
            var SupplierPart = new HashSet<Supplier_Part>();
        }
        [Key]
        public int supplier_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public int feedback { get; set; }

        public Supplier_data(int supplierId, string sname, string semail, string sphone, string slocation, int feed)
        {
            this.supplier_id = supplierId;
            this.name = sname;
            this.email = semail;
            this.phone = sphone;
            this.location = slocation;
            this.feedback = feed;

        }
    }
}
