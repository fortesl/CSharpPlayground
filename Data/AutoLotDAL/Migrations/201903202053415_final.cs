namespace AutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "CustId", newName: "CustomerId");
            RenameIndex(table: "dbo.Orders", name: "IX_CustId", newName: "IX_CustomerId");
            DropPrimaryKey("dbo.CreditRisks");
            DropPrimaryKey("dbo.Orders");
            DropColumn("dbo.CreditRisks", "CustID");
            DropColumn("dbo.Orders", "OrderId");
            AddColumn("dbo.CreditRisks", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisks", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddPrimaryKey("dbo.CreditRisks", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            CreateIndex("dbo.CreditRisks", new[] { "LastName", "FirstName" }, unique: true, name: "IDX_CreditRisk_Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditRisks", "IDX_CreditRisk_Name");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.CreditRisks");
            DropColumn("dbo.Orders", "Timestamp");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.CreditRisks", "Timestamp");
            DropColumn("dbo.CreditRisks", "Id");
            AddColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisks", "CustID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.CreditRisks", "CustID");
            RenameIndex(table: "dbo.Orders", name: "IX_CustomerId", newName: "IX_CustId");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "CustId");
        }
    }
}
