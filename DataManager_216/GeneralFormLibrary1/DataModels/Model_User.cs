using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace GeneralFormLibrary1.DataModels
{
    [Table("Users")]
    public class Model_User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SystemName { get; set; }

        public Model_User()
        {

        }

        public Model_User(string firstName, string lastName, string email, string systemName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            SystemName = systemName;
        }

    }
}

