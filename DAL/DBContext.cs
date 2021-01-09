using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class DBContext: DbContext
    {
        public DBContext() : base("Test")
        {
            Database.SetInitializer(new Init());
        }

        public DbSet<User> Users { get; set; }
    }
}