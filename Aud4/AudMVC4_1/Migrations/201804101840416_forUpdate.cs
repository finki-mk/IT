namespace AudMVC4_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Movie_id", "dbo.Movies");
            DropIndex("dbo.Clients", new[] { "Movie_id" });
            CreateTable(
                "dbo.MovieClients",
                c => new
                    {
                        Movie_id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_id, t.Client_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_id, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.Movie_id)
                .Index(t => t.Client_Id);
            
            DropColumn("dbo.Clients", "Movie_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Movie_id", c => c.Int());
            DropForeignKey("dbo.MovieClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.MovieClients", "Movie_id", "dbo.Movies");
            DropIndex("dbo.MovieClients", new[] { "Client_Id" });
            DropIndex("dbo.MovieClients", new[] { "Movie_id" });
            DropTable("dbo.MovieClients");
            CreateIndex("dbo.Clients", "Movie_id");
            AddForeignKey("dbo.Clients", "Movie_id", "dbo.Movies", "id");
        }
    }
}
