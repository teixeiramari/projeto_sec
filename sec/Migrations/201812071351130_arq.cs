namespace sec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arq : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Arquivo", "Extensao");
            DropColumn("dbo.Arquivo", "Tamanho");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arquivo", "Tamanho", c => c.Int(nullable: false));
            AddColumn("dbo.Arquivo", "Extensao", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
