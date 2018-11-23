namespace sec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arquivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arquivo", "IdUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "Usuario_Id", c => c.Int());
            CreateIndex("dbo.Arquivo", "IdUsuario");
            CreateIndex("dbo.Usuario", "Usuario_Id");
            AddForeignKey("dbo.Usuario", "Usuario_Id", "dbo.Usuario", "Id");
            AddForeignKey("dbo.Arquivo", "IdUsuario", "dbo.Usuario", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arquivo", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Usuario", new[] { "Usuario_Id" });
            DropIndex("dbo.Arquivo", new[] { "IdUsuario" });
            DropColumn("dbo.Usuario", "Usuario_Id");
            DropColumn("dbo.Arquivo", "IdUsuario");
        }
    }
}
