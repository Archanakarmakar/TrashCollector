namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CityName", c => c.String());
            AddColumn("dbo.Customers", "StateName", c => c.String());
            AddColumn("dbo.Customers", "WeeklyPickupDay", c => c.String());
            AddColumn("dbo.Customers", "PickupCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "OneTimePickupDate", c => c.String());
            AddColumn("dbo.Customers", "SuspendPickupStart", c => c.String());
            AddColumn("dbo.Customers", "SuspendPickupStop", c => c.String());
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "PickUp");
            DropColumn("dbo.Customers", "PicKupDate");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "SuspendedStart");
            DropColumn("dbo.Customers", "SuspendedEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SuspendedEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "SuspendedStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "PicKupDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "PickUp", c => c.String());
            AlterColumn("dbo.Customers", "ZipCode", c => c.Double(nullable: false));
            DropColumn("dbo.Employees", "ZipCode");
            DropColumn("dbo.Customers", "SuspendPickupStop");
            DropColumn("dbo.Customers", "SuspendPickupStart");
            DropColumn("dbo.Customers", "OneTimePickupDate");
            DropColumn("dbo.Customers", "PickupCompleted");
            DropColumn("dbo.Customers", "WeeklyPickupDay");
            DropColumn("dbo.Customers", "StateName");
            DropColumn("dbo.Customers", "CityName");
        }
    }
}
