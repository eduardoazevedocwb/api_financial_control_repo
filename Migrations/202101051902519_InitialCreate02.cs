namespace api_financial_control.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate02 : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entities");
        }
    }
}
