using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryofLMS.Interfaces;

namespace LibraryofLMS.BL
{
    public class LibrarianBL: MUserBL
    {
        public LibrarianBL(string username, string password) : base(username,password,"Librarian")
        {

        }

    }
}
