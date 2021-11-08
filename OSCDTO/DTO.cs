using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCDTO
{
    public class Customer
    {
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
    public class Admin{
        string user ="admin";
        string pass = "admin";

        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
    }

}
