namespace api_financial_control.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.Addresses",
    c => new
    {
        ID = c.Int(nullable: false, identity: true),
        Street = c.String(),
        Number = c.Int(nullable: false),
        Neighborhood = c.String(),
        City = c.String(),
        State = c.String(),
        Country = c.String(),
        Code = c.Int(nullable: false),
        Active = c.Boolean(nullable: false),
        Registration_date = c.DateTime(nullable: false),
    })
    .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Applications",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ID_Cost_center = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Companies",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    System_access = c.Boolean(nullable: false),
                    Name = c.String(),
                    Document = c.Int(nullable: false),
                    Municipal_document = c.Int(nullable: false),
                    Contract_number = c.Int(nullable: false),
                    ID_Adrress = c.Int(nullable: false),
                    ID_Contact = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Contacts",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Number = c.Int(nullable: false),
                    Email = c.String(),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Cost_center",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ID_Department = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Departments",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Financial_structure_access",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ID_Person = c.Int(nullable: false),
                    ID_Financial_structure = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Financial_structure",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ID_Department = c.Int(nullable: false),
                    ID_Cost_center = c.Int(nullable: false),
                    ID_Application = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Financial_value",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ID_Financial_structure = c.Int(nullable: false),
                    MyProperty = c.Int(nullable: false),
                    Simplified = c.Boolean(nullable: false),
                    Document_type = c.String(),
                    Document = c.Int(nullable: false),
                    Value = c.Double(nullable: false),
                    Doc_date = c.DateTime(nullable: false),
                    Doc_expiration = c.DateTime(nullable: false),
                    ID_Company = c.Int(nullable: false),
                    Value_type = c.String(),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Logins",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ID_Person = c.Int(nullable: false),
                    Secret_Code = c.String(),
                    ID_Secret_question = c.Int(nullable: false),
                    Secret_answer = c.String(),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.People",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Document_type = c.String(),
                    Document = c.Int(nullable: false),
                    Birth = c.DateTime(nullable: false),
                    ID_Company = c.Int(nullable: false),
                    ID_PersonUp = c.Int(nullable: false),
                    ID_Contact = c.Int(nullable: false),
                    ID_Address = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Secret_question",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.View_access",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ID_Person = c.Int(nullable: false),
                    ID_View = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Views",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Active = c.Boolean(nullable: false),
                    Registration_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.Views");
            DropTable("dbo.View_access");
            DropTable("dbo.Secret_question");
            DropTable("dbo.People");
            DropTable("dbo.Logins");
            DropTable("dbo.Financial_value");
            DropTable("dbo.Financial_structure");
            DropTable("dbo.Financial_structure_access");
            DropTable("dbo.Departments");
            DropTable("dbo.Cost_center");
            DropTable("dbo.Contacts");
            DropTable("dbo.Companies");
            DropTable("dbo.Applications");
            DropTable("dbo.Addresses");
        }
    }
}
