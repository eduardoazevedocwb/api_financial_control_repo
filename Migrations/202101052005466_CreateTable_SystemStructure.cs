namespace api_financial_control.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable_SystemStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.System_structure",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Items = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Registration_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Entities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Entities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Object = c.String(),
                        Action = c.String(),
                        Command = c.String(),
                        Command_type = c.String(),
                        Result = c.String(),
                        Result_type = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Registration_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.System_structure");
        }
    }
}
