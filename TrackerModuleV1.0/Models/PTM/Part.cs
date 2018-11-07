using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerModuleV1._0.Models.PTM
{
    public class Part
    {
        public Part()
        {
            this.Suppliers = new HashSet<Supplier>();
        }
        [Key]
        public string PartId { get; set; }
        [Required]
        public string PartName { get; set; }
        public string PartDescription { get; set; }
        public string NovenaTecPartNumber { get; set; }
        public string SwissRanksPartNumber { get; set; }
        public string OEMPartNumber { get; set; }
        public string VendorPartNumber { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public string CreatedUserId { get; set; }
        public string ApprovedUserId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        //public IEnumerable<HttpPostedFileBase> File { get; set; }
        public User CreatedBy { get; set; }
        public User ApproveBy { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public  ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }

    public enum Status
    {
        Not_Approved,
        Approved,
        In_Progress
    }
}