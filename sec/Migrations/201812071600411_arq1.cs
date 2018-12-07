namespace sec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arq1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arquivo", "extensao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Arquivo", "extensao");
        }
    }
}
