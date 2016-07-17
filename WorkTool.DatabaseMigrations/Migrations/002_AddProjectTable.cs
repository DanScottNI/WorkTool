using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace WorkTool.DatabaseMigrations.Migrations
{
    [Migration(2, "Added project table")]
    public class _002_AddProjectTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Project");
        }

        public override void Up()
        {
            Create.Table("Project").WithDescription("Projects table.")
                .WithColumn("ProjectId").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProjectName").AsString(int.MaxValue).NotNullable();
        }
    }
}
