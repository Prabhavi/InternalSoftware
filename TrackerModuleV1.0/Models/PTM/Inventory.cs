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
        public string PartId { get; set; }
        public Part Part { get; set; }
        [Key]
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        //[Display(Name = "Inventory ID")]
        //public string InventoryId { get; set; }

        public string UoM { get; set; }
        public int UsedQnty { get; set; }
        public int InStock { get; set; }
        public int SafetyStock { get; set; }
        public int RackNo { get; set; }
        public int LineNo { get; set; }
        public string StoreLocation { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime LastUsedDate { get; set; }
        public string LastUserId { get; set; }
        public User LastUser { get; set; }
    }
}