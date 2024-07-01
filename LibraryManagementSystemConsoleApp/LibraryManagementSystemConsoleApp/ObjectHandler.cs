using LibraryofLMS.DL.FH;
using LibraryofLMS.DL.FH.LibraryofLMS.DL.FH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsoleApp
{
    public class ObjectHandler
    {
        private static LibrarianDL_FH LibrarianDL = LibrarianDL_FH.GetLibrarianDL_FH("D:\\Business\\FileHandling\\Librarian.txt");
        private static BookDL_FH BookDL = BookDL_FH.GetBookDL_FH("D:\\Business\\FileHandling\\Books.txt");


        public static LibrarianDL_FH GetLibrarianDL()
        {
            return LibrarianDL;
        }

        public static BookDL_FH GetBookDL()
        {
            return BookDL;
        }
    }
}
