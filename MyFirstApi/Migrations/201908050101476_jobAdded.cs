namespace MyFirstApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Perfil = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Created = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfils", t => t.Perfil, cascadeDelete: true)
                .Index(t => t.Perfil);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Perfil", "dbo.Perfils");
            DropIndex("dbo.Jobs", new[] { "Perfil" });
            DropTable("dbo.Jobs");
        }
    }
}
