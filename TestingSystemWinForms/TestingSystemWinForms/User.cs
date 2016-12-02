using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystemWinForms
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {

        }
    }

    public class User_Db : DbContext
    {
        public User_Db()
            : base("TestingSystemWinForms.Properties.Settings.Setting")
        { }
        public DbSet<User> Users { get; set; }
    }

   
}
