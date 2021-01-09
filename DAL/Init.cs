using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class Init : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var user = new User
            {
                Id = 1,
                Name = "bar",
                Age = 24
            };

            var user1 = new User
            {
                Id = 2,
                Name = "or",
                Age = 24
            };
            context.Users.Add(user);
            context.Users.Add(user1);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}