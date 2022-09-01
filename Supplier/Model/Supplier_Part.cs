using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplierMicroservice
{
    public class Supplier_Part
    {
        //public int id { get; set; }
        [Key]
        public int id { get; set; }
        public int partid { get; set; }
        public string partname { get; set; }
        public int quantity { get; set; }
        public int timeperiod { get; set; }
        [ForeignKey("Supplier")]
        public int sid { get; set; }
    }

    //public Supplier_Part(int Id, int Partid, string partName, int Quantity, int timePeriod, int Sid)
    //{
    //    this.id

    //}
    //public Supplier_part()
    //{

    //}
    //public Supplier_Part(int Id, int Partid, string partName, int Quantity, int timePeriod, int Sid)
    //{
    //    this.id = Id;
    //    this.partid = Partid;
    //    this.partname = partName;
    //    this.quantity = Quantity;
    //    this.timeperiod = timePeriod;
    //    this.sid = Sid;
    //}

    //public Supplier_Part()
    //{

    //}
}
