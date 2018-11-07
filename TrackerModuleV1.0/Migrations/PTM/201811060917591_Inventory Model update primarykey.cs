namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryModelupdateprimarykey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Inventory");
            AddColumn("dbo.Inventory", "PartId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Inventory", "SupplierId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Inventory", new[] { "PartId", "SupplierId" });
            CreateIndex("dbo.Inventory", "PartId");
            CreateIndex("dbo.Inventory", "SupplierId");
            AddForeignKey("dbo.Inventory", "PartId", "dbo.Part", "PartId", cascadeDelete: true);
            AddForeignKey("dbo.Inventory", "SupplierId", "dbo.Supplier", "SupplierId", cascadeDelete: true);
            DropColumn("dbo.Inventory", "InventoryId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Inventory", "InventoryId", c => c.String(nullable: false, maxLength: 128));
            //DropForeignKey("dbo.Inventory", "SupplierId", "dbo.Supplier");
            //DropForeignKey("dbo.Inventory", "PartId", "dbo.Part");
            //DropIndex("dbo.Inventory", new[] { "SupplierId" });
            //DropIndex("dbo.Inventory", new[] { "PartId" });
            //DropPrimaryKey("dbo.Inventory");
            //DropColumn("dbo.Inventory", "SupplierId");
            //DropColumn("dbo.Inventory", "PartId");
            //AddPrimaryKey("dbo.Inventory", "InventoryId");
        }
    }
}
