namespace sec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preferencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 120),
                        Nick = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(nullable: false),
                        Foto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioPreferencias",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        Preferencia_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Preferencia_Id })
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Preferencia", t => t.Preferencia_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Preferencia_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioPreferencias", "Preferencia_Id", "dbo.Preferencia");
            DropForeignKey("dbo.UsuarioPreferencias", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.UsuarioPreferencias", new[] { "Preferencia_Id" });
            DropIndex("dbo.UsuarioPreferencias", new[] { "Usuario_Id" });
            DropTable("dbo.UsuarioPreferencias");
            DropTable("dbo.Usuario");
            DropTable("dbo.Preferencia");
        }
    }
}
