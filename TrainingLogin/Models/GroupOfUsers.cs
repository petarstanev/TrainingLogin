using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingLogin.Models
{
    public class GroupOfUsers
    {
        public static List<User> Users { get; set; } = new List<User>();
        public GroupOfUsers()
        {
            Users = new List<User>();
        }
    }
}