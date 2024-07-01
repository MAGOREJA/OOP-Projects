using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryofLMS.Interfaces;


namespace LibraryofLMS.BL
{
    public class StudentBL: MUserBL
    {
        public StudentBL(string username, string password) : base(username, password, "Student")
        {

        }

    }
}
