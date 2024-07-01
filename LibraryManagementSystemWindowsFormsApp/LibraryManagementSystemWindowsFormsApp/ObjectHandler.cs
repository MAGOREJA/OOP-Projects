using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryofLMS.DL.DB;
using LibraryofLMS.DL.FH;
using LibraryofLMS.BL;
using LibraryofLMS.Interfaces;
using LibraryofLMS.DL.FH.LibraryofLMS.DL.FH;

namespace LibraryManagementSystemWindowsFormsApp
{
    public class ObjectHandler
    {

        public static string connectionstring = "server=localhost\\SQLEXPRESS;database=LibraryMS;Trusted_Connection=True;";
        private static LibrarianDL_DB LibrarianDL = LibrarianDL_DB.GetLibrarianDL_DB(connectionstring);
        private static StudentDL_DB StudentDL = StudentDL_DB.GetStudentDL_DBInstance(connectionstring);
        private static BookDL_DB BookDL = BookDL_DB.GetBookDL_DB(connectionstring);

        //private static LibrarianDL_FH LibrarianDL = LibrarianDL_FH.GetLibrarianDL_FH("D:\\Business\\FileHandling\\Librarian.txt");
        //private static BookDL_FH BookDL = BookDL_FH.GetBookDL_FH("D:\\Business\\FileHandling\\Books.txt");
        public static LibrarianDL_DB GetLibrarianDL()
        {
            return LibrarianDL;
        }
        public static StudentDL_DB GetStudentDL()
        {
            return StudentDL;
        }
        public static BookDL_DB GetBookDL()
        {
            return BookDL;
        }

        //public static LibrarianDL_FH GetLibrarianDL()
        //{
        //    return LibrarianDL;
        //}

        //public static BookDL_FH GetBookDL()
        //{
        //    return BookDL;
        //}
    }
}
