namespace exercise_planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Plans", "DayOfWeek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plans", "DayOfWeek", c => c.Int(nullable: false));
        }
    }
}
