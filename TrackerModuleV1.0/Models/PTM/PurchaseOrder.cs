using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerModuleV1._0.Models.PTM
{
    public class PurchaseOrder
    {
        [Key]
        public string PurchaseOrderID { get; set; }
        public string ProjectNumber { get; set; }
        public Project Project { get; set; }
        [Required]
        public string PartNumber { get; set; }
        public Part Part { get; set; }
        public string  UOM { get; set; }
        public string Currency { get; set; }
        public int UnitPrice { get; set; }
        public int OpenOrderQuantity { get; set; }
        public string ApproveStatus { get; set; }
        public string ApproveUserId { get; set; }
        public User ApproveBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}", ApplyFormatInEditMode = true)]
        public DateTime DeliverDate { get; set; }
        public string DeliveryLocation { get; set; }
        public int DeliveredQuantity { get; set; }
        public int QuantityInTransit { get; set; }
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string OrderById { get; set; }
        public User OrderBy { get; set; }
    }
}