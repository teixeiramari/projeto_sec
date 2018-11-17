namespace sec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacaobd1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Arq = c.Binary(nullable: false),
                        Descricao = c.String(maxLength: 250),
                        Extensao = c.String(nullable: false, maxLength: 50),
                        Tamanho = c.Int(nullable: false),
                        Caminho = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PreferenciaArquivoes",
                c => new
                    {
                        Preferencia_Id = c.Int(nullable: false),
                        Arquivo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Preferencia_Id, t.Arquivo_Id })
                .ForeignKey("dbo.Preferencia", t => t.Preferencia_Id, cascadeDelete: true)
                .ForeignKey("dbo.Arquivo", t => t.Arquivo_Id, cascadeDelete: true)
                .Index(t => t.Preferencia_Id)
                .Index(t => t.Arquivo_Id);
            
            AddColumn("dbo.Usuario", "Nome", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreferenciaArquivoes", "Arquivo_Id", "dbo.Arquivo");
            DropForeignKey("dbo.PreferenciaArquivoes", "Preferencia_Id", "dbo.Preferencia");
            DropIndex("dbo.PreferenciaArquivoes", new[] { "Arquivo_Id" });
            DropIndex("dbo.PreferenciaArquivoes", new[] { "Preferencia_Id" });
            DropColumn("dbo.Usuario", "Nome");
            DropTable("dbo.PreferenciaArquivoes");
            DropTable("dbo.Arquivo");
        }
    }
}
