using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingLogin.Models
{
    public class GroupOfUsers
    {
        public List<User> Users { get; set; }
        public GroupOfUsers()
        {
            Users = new List<User>();
        }
    }
}