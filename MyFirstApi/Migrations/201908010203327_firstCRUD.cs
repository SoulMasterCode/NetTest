namespace MyFirstApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstCRUD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Image = c.String(),
                        Rol_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RolUsers", t => t.Rol_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Rol_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.RolUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Age = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Perfils", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Perfils", "Rol_Id", "dbo.RolUsers");
            DropIndex("dbo.Perfils", new[] { "User_Id" });
            DropIndex("dbo.Perfils", new[] { "Rol_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.RolUsers");
            DropTable("dbo.Perfils");
        }
    }
}
