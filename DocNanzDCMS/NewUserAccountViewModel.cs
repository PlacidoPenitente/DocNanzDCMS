using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public class NewUserAccountViewModel
    {
        private User user;
        public String FirstName
        {
            get { return user.FirstName; }
            set { user.FirstName = value; }
        }

        public String MiddleName
        {
            get { return user.MiddleName; }
            set { user.MiddleName = value; }
        }

        public String LastName
        {
            get { return user.LastName; }
            set { user.LastName = value; }
        }

        public NewUserAccountViewModel()
        {
            user = new User();
        }
    }
}
