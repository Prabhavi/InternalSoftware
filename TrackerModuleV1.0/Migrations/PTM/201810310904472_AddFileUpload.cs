namespace TrackerModuleV1._0.Migrations.PTM
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Part", "FileName", c => c.String());
            AddColumn("dbo.Part", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Part", "FilePath");
            DropColumn("dbo.Part", "FileName");
        }
    }
}
