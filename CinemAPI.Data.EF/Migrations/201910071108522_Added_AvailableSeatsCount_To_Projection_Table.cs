namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_AvailableSeatsCount_To_Projection_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projections", "AvailableSeatsCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projections", "AvailableSeatsCount");
        }
    }
}
