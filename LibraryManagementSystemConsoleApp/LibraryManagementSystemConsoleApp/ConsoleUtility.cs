using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LibraryofLMS.BL;
using LibraryofLMS.DL.FH;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using LibraryManagementSystemConsoleApp.UI;

namespace LibraryManagementSystemConsoleApp
{
    public class ConsoleUtility
    {
        public static string mainpage()
        {
            Console.Clear(); ;
            header();
            string option;
            Console.WriteLine("Welcome....");
            Console.WriteLine();
            Console.WriteLine(" Enter Any Of The Following: ");
            Console.WriteLine(" 1. Sign In: ");
            Console.WriteLine(" 2. Sign Up: ");
            Console.WriteLine(" 3. Exit: ");
            Console.WriteLine();

            Console.Write("Select option: ");
            option = Console.ReadLine();
            return option;
        }
        public static string adminmenu()
        {

            string options;
            Console.Clear();
            header();
            Console.WriteLine("Welcome to Admin menu");
            Console.WriteLine("_________________________.");
            Console.WriteLine("Select One Of the Following:");
            Console.WriteLine("1.View All the Books.");
            Console.WriteLine("2.Add Any Book.");
            Console.WriteLine("3.Remove Any Book.");
            Console.WriteLine("4.Update Any Book.");
            Console.WriteLine("5.View All the Users.");
            Console.WriteLine("6.Return to Credentials Page.");
            Console.WriteLine();
            Console.Write("Select the option: ");
            options = Console.ReadLine();
            return options;
        }
//        public static string student()
//        {
//            string option1;
//            Console.Clear();
//            header();
//            Console.WriteLine("Welcome to Student Menu");
//            Console.WriteLine("__________________________.");
//            Console.WriteLine("Select One Of the Following:");
//            Console.WriteLine("1.View List of All books.");
//            Console.WriteLine("2.Search Books.");
//            Console.WriteLine("3.Change My Password.");
//            Console.WriteLine("4.Credentials page.");
//            Console.WriteLine();
//            Console.Write("Select the option: ");
//            option1 = Console.ReadLine();
//            return option1;
//        }
        public static void header()
        {
            Console.WriteLine("*******************************************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine(".d8888. db   db  .d8b.   .d8b.  d8b   db d8888b.  .d8b.  d8888b.      db      d888888b d8888b. d8888b.  .d8b.  d8888b. db    db");
            Console.WriteLine("88'  YP 88   88 d8' `8b d8' `8b 888o  88 88  `8D d8' `8b 88  `8D      88        `88'   88  `8D 88  `8D d8' `8b 88  `8D `8b d8' ");
            Console.WriteLine("`8bo.   88ooo88 88ooo88 88ooo88 88V8o 88 88   88 88ooo88 88oobY'      88         88    88oooY' 88oobY' 88ooo88 88oobY'  `8bd8' "); 
            Console.WriteLine("  `Y8b. 88~~~88 88~~~88 88~~~88 88 V8o88 88   88 88~~~88 88`8b        88         88    88~~~b. 88`8b   88~~~88 88`8b      88   ");
            Console.WriteLine("db   8D 88   88 88   88 88   88 88  V888 88  .8D 88   88 88 `88.      88booo.   .88.   88   8D 88 `88. 88   88 88 `88.    88   ");
            Console.WriteLine("`8888Y' YP   YP YP   YP YP   YP VP   V8P Y8888D' YP   YP 88   YD      Y88888P Y888888P Y8888P' 88   YD YP   YP 88   YD    YP   ");
            Console.WriteLine();
            Console.WriteLine("*******************************************************************************************************************************");
            Console.WriteLine();

        }
        public static void clear()
        {

            Console.WriteLine("Press any Key to Continue ");
            Console.ReadKey();
            Console.Clear();
        }

        public static void signin()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("Welcome to signin page.............. :) ");
            Console.WriteLine();
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            LibrarianBL signinup = new LibrarianBL(name, password);
            
                if (ObjectHandler.GetLibrarianDL().IsLibrarianExist(name, password))
                {
                    LibrarianUI.Adminoptions(adminmenu());
                }
            
                else
                {
                    Console.WriteLine("User not found");
                    Console.WriteLine();
                    ConsoleUtility.clear();
                }
        }
        public static void signup()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("Welcome to signup page.............. :) ");
            Console.WriteLine();
            string cname, cpass;
            bool t = true;
            while (t)
            {
                Console.Clear();
                ConsoleUtility.header();
                Console.Write("Enter your Name: ");
                cname = Console.ReadLine();
                Console.Write("Enter your Password: ");
                cpass = Console.ReadLine();
                
                if (ObjectHandler.GetLibrarianDL().CheckValidLibrarianName(cname))
                {
                        LibrarianBL signin = new LibrarianBL(cname, cpass);
                        ObjectHandler.GetLibrarianDL().AddLibrarian(signin);
                        Console.WriteLine("successfully signed in.");
                    ConsoleUtility.clear();
                    t=false;
                }
                else
                {
                    Console.WriteLine("Enter valid username");
                }
                 
            }
        }

    }
}
