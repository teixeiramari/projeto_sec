namespace sec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arquivo1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Usuario", new[] { "Usuario_Id" });
            CreateTable(
                "dbo.UsuarioUsuarios",
                c => new
                    {
                        Usuario_Id = c.Int(nullable: false),
                        Usuario_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Usuario_Id1 })
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id1)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Usuario_Id1);
            
            DropColumn("dbo.Usuario", "Usuario_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Usuario_Id", c => c.Int());
            DropForeignKey("dbo.UsuarioUsuarios", "Usuario_Id1", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioUsuarios", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.UsuarioUsuarios", new[] { "Usuario_Id1" });
            DropIndex("dbo.UsuarioUsuarios", new[] { "Usuario_Id" });
            DropTable("dbo.UsuarioUsuarios");
            CreateIndex("dbo.Usuario", "Usuario_Id");
            AddForeignKey("dbo.Usuario", "Usuario_Id", "dbo.Usuario", "Id");
        }
    }
}
