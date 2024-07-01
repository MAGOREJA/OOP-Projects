using LibraryofLMS.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsoleApp.UI
{
    public class LibrarianUI
    {

        public static void Adminoptions(string options)
        {
            bool t = true;
            while (t == true)
            {
                options = ConsoleUtility.adminmenu();
                if (options == "1")
                {
                    userlist();
                    Console.ReadLine();

                }
                if (options == "2")
                {
                    BooksUI.addbooks();
                }
                if (options == "3")
                {
                    BooksUI.removebook();
                }
                if (options == "4")
                {
                    BooksUI.updatebook();
                }
                if (options == "5")
                {
                    BooksUI.booklist();
                    Console.ReadLine();
                }
                if (options == "6")
                {
                    t = false;
                }
            }
                ConsoleUtility.clear();
        }


        public static void userlist()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("User List....");
            Console.WriteLine();

            List<LibrarianBL> librarians = ObjectHandler.GetLibrarianDL().GetAllLibrarians();

        foreach(var librarian in librarians)
            { 
                Console.WriteLine("Username\t\tPassword");
                Console.WriteLine(librarian.getname()+"\t\t"+librarian.getpassword());
            }
        }


    }
}
