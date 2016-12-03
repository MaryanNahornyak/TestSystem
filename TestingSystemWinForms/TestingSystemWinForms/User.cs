using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystemWinForms
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Key]
        public int Id { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<TestResult> testResults { get; set; }

        public User()
        {

        }
    }

    public class TestResult
    {
        [ForeignKey("TestResult_User")]
        public User User { get; set; }

        [Key]
        public int testId { get; set; }
        [ForeignKey("User")]
        public int userId { get; set; }
        public string result { get; set; }
    }

    public class User_Db : DbContext
    {
        public User_Db()
            : base("TestingSystemWinForms.Properties.Settings.Setting")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }

   
}
