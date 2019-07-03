namespace Terminal.Data.Config
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numcontaadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contas", "NumConta", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contas", "NumConta");
        }
    }
}
