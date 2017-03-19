using System.Data.Entity;
using CarAdverts.Data;
using CarAdverts.Data.Migrations;

namespace CarAdverts.Web
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarAdvertsSystemDbContext, Configuration>());
            CarAdvertsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}