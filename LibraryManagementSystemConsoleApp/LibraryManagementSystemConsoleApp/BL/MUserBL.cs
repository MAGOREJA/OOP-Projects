using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsoleApp.BL
{
    class MUserBL
    {
        private string name = "";
        private string password = "";
        private string role = "";
        private int currentindex;
        public MUserBL()
        {

        }
        public MUserBL(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;

        }
        public MUserBL(string name, string password)
        {
            this.name = name;
            this.password = password;

        }
        public int getindex()
        {
            return currentindex;
        }
        public string getname()
        {
            return name;
        }
        public string getpassword()
        {
            return password;
        }
        public string getrole()
        {
            return role;
        }
        public void setname(string name)
        {
            this.name = name;
        }
        public void setpassword(string name)
        {
            this.password = name;
        }
        public void setindex(int x)
        {
            this.currentindex = x;
        }
        public void setrole(string role)
        {
            this.role = role;
        }

    }
}
