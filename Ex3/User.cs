using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class User
    {
        public string password;
        public string backpassword;
        public string login;

        public User(string login)
        {
            this.login = login;
            this.password = Guid.NewGuid().ToString().Substring(0, 10);
        }

        public override string ToString()
        {
            return password;
        }

    }
}
