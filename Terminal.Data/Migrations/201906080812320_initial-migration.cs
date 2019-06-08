namespace Terminal.Data.Config
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LimiteCredito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataAbertura = c.DateTime(nullable: false),
                        DataCriacao = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        Correntista_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Correntistas", t => t.Correntista_Id, cascadeDelete: true)
                .Index(t => t.Correntista_Id);
            
            CreateTable(
                "dbo.Correntistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Nome = c.String(nullable: false),
                        DataCriacao = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lancamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Operacao = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(),
                        DataCriacao = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        Conta_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contas", t => t.Conta_Id)
                .Index(t => t.Conta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lancamentoes", "Conta_Id", "dbo.Contas");
            DropForeignKey("dbo.Contas", "Correntista_Id", "dbo.Correntistas");
            DropIndex("dbo.Lancamentoes", new[] { "Conta_Id" });
            DropIndex("dbo.Contas", new[] { "Correntista_Id" });
            DropTable("dbo.Lancamentoes");
            DropTable("dbo.Correntistas");
            DropTable("dbo.Contas");
        }
    }
}
