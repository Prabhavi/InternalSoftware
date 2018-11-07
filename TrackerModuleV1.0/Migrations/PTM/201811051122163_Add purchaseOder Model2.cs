namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddpurchaseOderModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrder",
                c => new
                    {
                        PurchaseOrderID = c.String(nullable: false, maxLength: 128),
                        ProjectNumber = c.String(nullable: false, maxLength: 128),
                        PartNumber = c.String(nullable: false, maxLength: 128),
                        UOM = c.String(),
                        Currency = c.String(),
                        UnitPrice = c.Int(nullable: false),
                        OpenOrderQuantity = c.Int(nullable: false),
                        ApproveStatus = c.String(),
                        ApproveUserId = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        DeliverDate = c.DateTime(nullable: false),
                        DeliveryLocation = c.String(),
                        DeliveredQuantity = c.Int(nullable: false),
                        QuantityInTransit = c.Int(nullable: false),
                        SupplierId = c.String(nullable: false, maxLength: 128),
                        OrderById = c.String(nullable: false, maxLength: 128),
                        ApproveBy_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PurchaseOrderID)
                .ForeignKey("dbo.User", t => t.ApproveBy_UserId)
                .ForeignKey("dbo.User", t => t.OrderById, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => t.PartNumber, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.ProjectNumber, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.ProjectNumber)
                .Index(t => t.PartNumber)
                .Index(t => t.SupplierId)
                .Index(t => t.OrderById)
                .Index(t => t.ApproveBy_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrder", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.PurchaseOrder", "ProjectNumber", "dbo.Project");
            DropForeignKey("dbo.PurchaseOrder", "PartNumber", "dbo.Part");
            DropForeignKey("dbo.PurchaseOrder", "OrderById", "dbo.User");
            DropForeignKey("dbo.PurchaseOrder", "ApproveBy_UserId", "dbo.User");
            DropIndex("dbo.PurchaseOrder", new[] { "ApproveBy_UserId" });
            DropIndex("dbo.PurchaseOrder", new[] { "OrderById" });
            DropIndex("dbo.PurchaseOrder", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrder", new[] { "PartNumber" });
            DropIndex("dbo.PurchaseOrder", new[] { "ProjectNumber" });
            DropTable("dbo.PurchaseOrder");
        }
    }
}
