using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace WorkTool.DatabaseMigrations.Migrations
{
    [Migration(1, "Adding user table.")]
    public class _001_AddUsers : Migration
    {
        public override void Down()
        {
            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("User").WithDescription("User table.")
                .WithColumn("UserId").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserName").AsAnsiString(100).NotNullable()
                .WithColumn("Forename").AsString(int.MaxValue).NotNullable()
                .WithColumn("Surname").AsString(int.MaxValue).NotNullable();
        }
    }
}
