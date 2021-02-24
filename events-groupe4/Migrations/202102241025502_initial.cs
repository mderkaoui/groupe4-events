namespace events_groupe4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganisateurId = c.Int(nullable: false),
                        dateParution = c.DateTime(nullable: false),
                        contenu = c.String(),
                        etat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.OrganisateurId, cascadeDelete: true)
                .Index(t => t.OrganisateurId);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        description = c.String(nullable: false),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        publie = c.Boolean(nullable: false),
                        categorieId = c.Int(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categorieId)
                .Index(t => t.categorieId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvenementId = c.Int(),
                        DateCreation = c.DateTime(nullable: false),
                        AdherentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.AdherentId)
                .ForeignKey("dbo.Events", t => t.EvenementId)
                .Index(t => t.EvenementId)
                .Index(t => t.AdherentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "EvenementId", "dbo.Events");
            DropForeignKey("dbo.Reservations", "AdherentId", "dbo.Utilisateurs");
            DropForeignKey("dbo.Events", "categorieId", "dbo.Categories");
            DropForeignKey("dbo.Articles", "OrganisateurId", "dbo.Utilisateurs");
            DropIndex("dbo.Reservations", new[] { "AdherentId" });
            DropIndex("dbo.Reservations", new[] { "EvenementId" });
            DropIndex("dbo.Events", new[] { "categorieId" });
            DropIndex("dbo.Articles", new[] { "OrganisateurId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Events");
            DropTable("dbo.Categories");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Articles");
        }
    }
}
