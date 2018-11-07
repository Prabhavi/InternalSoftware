namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryModelupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventory", "Part_PartId", "dbo.Part");
            DropForeignKey("dbo.Inventory", "Project_ProjectId", "dbo.Project");
            DropForeignKey("dbo.Inventory", "Supplier_SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Inventory", "User_UserId", "dbo.User");
            DropIndex("dbo.Inventory", new[] { "Part_PartId" });
            DropIndex("dbo.Inventory", new[] { "Project_ProjectId" });
            DropIndex("dbo.Inventory", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.Inventory", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Inventory", name: "LastUser_UserId", newName: "LastUserId");
            RenameIndex(table: "dbo.Inventory", name: "IX_LastUser_UserId", newName: "IX_LastUserId");
            AddColumn("dbo.Inventory", "InStock", c => c.Int(nullable: false));
            DropColumn("dbo.Inventory", "ShortDescription");
            DropColumn("dbo.Inventory", "MaterialType");
            DropColumn("dbo.Inventory", "UnitPrice");
            DropColumn("dbo.Inventory", "DeliveryStatus");
            DropColumn("dbo.Inventory", "DeliveryDate");
            DropColumn("dbo.Inventory", "OpenOrderQnty");
            DropColumn("dbo.Inventory", "QntyInTransit");
            DropColumn("dbo.Inventory", "DeliveryLocation");
            DropColumn("dbo.Inventory", "DeliveryQnty");
            DropColumn("dbo.Inventory", "Stock");
            DropColumn("dbo.Inventory", "Part_PartId");
            DropColumn("dbo.Inventory", "Project_ProjectId");
            DropColumn("dbo.Inventory", "Supplier_SupplierId");
            DropColumn("dbo.Inventory", "User_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "User_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Inventory", "Supplier_SupplierId", c => c.String(maxLength: 128));
            AddColumn("dbo.Inventory", "Project_ProjectId", c => c.String(maxLength: 128));
            AddColumn("dbo.Inventory", "Part_PartId", c => c.String(maxLength: 128));
            AddColumn("dbo.Inventory", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "DeliveryQnty", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "DeliveryLocation", c => c.String());
            AddColumn("dbo.Inventory", "QntyInTransit", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "OpenOrderQnty", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "DeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Inventory", "DeliveryStatus", c => c.String());
            AddColumn("dbo.Inventory", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Inventory", "MaterialType", c => c.String());
            AddColumn("dbo.Inventory", "ShortDescription", c => c.String());
            DropColumn("dbo.Inventory", "InStock");
            RenameIndex(table: "dbo.Inventory", name: "IX_LastUserId", newName: "IX_LastUser_UserId");
            RenameColumn(table: "dbo.Inventory", name: "LastUserId", newName: "LastUser_UserId");
            CreateIndex("dbo.Inventory", "User_UserId");
            CreateIndex("dbo.Inventory", "Supplier_SupplierId");
            CreateIndex("dbo.Inventory", "Project_ProjectId");
            CreateIndex("dbo.Inventory", "Part_PartId");
            AddForeignKey("dbo.Inventory", "User_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Inventory", "Supplier_SupplierId", "dbo.Supplier", "SupplierId");
            AddForeignKey("dbo.Inventory", "Project_ProjectId", "dbo.Project", "ProjectId");
            AddForeignKey("dbo.Inventory", "Part_PartId", "dbo.Part", "PartId");
        }
    }
}
