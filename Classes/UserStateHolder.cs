using CentralApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralApplication.Classes
{
    internal class UserStateHolder
    {
        private static UserStateHolder instance = null;

        private User currentUser;

        private UserStateHolder(User currentUser)
        {
            this.currentUser = currentUser;
        }

        public static void loginUser(User user)
        {
            if(instance == null)
            {
                instance = new UserStateHolder(user);
            }
        }
        public static User CurrentUser()
        {
            return instance.currentUser;
        }
    }
}
