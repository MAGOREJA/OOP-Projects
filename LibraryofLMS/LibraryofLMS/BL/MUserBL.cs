using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.BL
{
    public class MUserBL
    {
        private string name = "";
        private string password = "";
        private string role = "";
        public MUserBL()
        {

        }
        public MUserBL(string name, string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
            
        }
        // getters
        
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
        // setters
        public void setname(string name)
        {
            this.name = name;
        }
        public void setpassword(string name)
        {
            this.password = name;
        }
        public void setrole(string role)
        {
            this.role = role;
        }

    }
}
