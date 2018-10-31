using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerModuleV1._0.Models.PTM
{
    public class Inventory
    {

        [Key]
        [Display(Name = "Inventory ID")]
        public string InventoryId { get; set; }

        public Project Project { get; set; }
        public Part Part { get; set; }
        public string ShortDescription { get; set; }
        public string MaterialType { get; set; }
        public User User { get; set; }
        public string StoreLocation { get; set; }
        public decimal UnitPrice { get; set; }
        public Supplier Supplier { get; set; }
        public string DeliveryStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; }

        //[Display(Name = "Delivery Date")]
        //public DateTime DeliveryDate { get; set; }

        public int OpenOrderQnty { get; set; }
        public int QntyInTransit { get; set; }
        public string DeliveryLocation { get; set; }
        public int DeliveryQnty { get; set; }
        public string UoM { get; set; }
        public int UsedQnty { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Used Date")]
        public DateTime LastUsedDate { get; set; }

        //[Display(Name = "Last Used Date")]
        //public DateTime LastUsedDate { get; set; }

        public User LastUser { get; set; }
        public int Stock { get; set; }
        public int SafetyStock { get; set; }
        public int RackNo { get; set; }
        public int LineNo { get; set; }
    }
}