using CarAdverts.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarAdverts.Data
{
    public class CarAdvertsSystemDbContext : IdentityDbContext<User>
    {
        public CarAdvertsSystemDbContext()
            : base("CarAdvertsSystemDb")
        {
        }

        public static CarAdvertsSystemDbContext Create()
        {
            return new CarAdvertsSystemDbContext();
        }
    }
}
