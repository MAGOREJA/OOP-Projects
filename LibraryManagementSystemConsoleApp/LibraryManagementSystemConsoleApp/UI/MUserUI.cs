using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystemConsoleApp.BL;
using LibraryManagementSystemConsoleApp.DL;

namespace LibraryManagementSystemConsoleApp.UI
{
    class MUserUI
    {
        public static void signin()
        {
            MUserBL s = new MUserBL();
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("Welcome to signin page.............. :) ");
            Console.WriteLine();
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine();
            MUserBL signin = new MUserBL(name, password);
            bool ty = MUserDL.signincheck(signin);
            if (ty == false)
            {
                Console.WriteLine("User not found");
                ConsoleUtility.clear();
            }
        }
        public static void signup()
        {
            MUserBL s = new MUserBL();
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("Welcome to signup page.............. :) ");
            Console.WriteLine();
            string cname, cpass = "a";
            string crole;
            bool at = false;
            while (cpass.Length < 8)
            {
                bool chk = false;
                Console.Clear();
                ConsoleUtility.header();
                Console.Write("Enter your Name: ");
                cname = Console.ReadLine();
                Console.Write("Enter your Password: ");
                cpass = Console.ReadLine();
                Console.Write("Enter your Role: ");
                crole = Console.ReadLine();
                if (cpass.Length < 8)
                {
                    chk = true;
                    Console.WriteLine("Your PassWord is less than 8 Characters Try again");
                    Console.ReadKey();
                }
                if (chk == false)
                {
                    at = MUserDL.existeduser(cname);
                    if (at == true)
                    {
                        Console.WriteLine("user Existed.");
                        ConsoleUtility.clear();
                    }
                    if (at == false)
                    {
                        MUserBL user = new MUserBL(cname, cpass,crole);
                        MUserDL.adduserlist(user);
                        Console.WriteLine("New id has been created successfully...........");
                        //saveuserdata(stu1);
                        //savebooksdata(stu2);
                        //saveborrowdata(stu);

                    }
                }
            }
        }
        public static void userlist()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("User List....");
            Console.WriteLine();
            bool t = MUserDL.USERLIST();
            if (t == false)
            {
                Console.WriteLine("No user existed.............");
            }
            else if (t == true)
            {
                MUserDL.PRINTUSERLIST();
            }
            ConsoleUtility.clear();
            ConsoleUtility.header();
        }
        public static void Adminoptions(string options)
        {
            bool t = true;
            while (t == true)
            {
                options = ConsoleUtility.adminmenu();
                if (options == "1")
                {
                    booksui.addbooks();
                }
                if (options == "2")
                {
                    changeadminpas();
                }
                if (options == "3")
                {
                    userlist();
                }
                if (options == "4")
                {
                    removeuser();
                }
                if (options == "5")
                {
                    libraryui.borrowhistory();
                }
                if (options == "6")
                {
                    booksui.booklist();
                }
                if (options == "7")
                {
                    booksui.removebook();
                }
                if (options == "8")
                {
                    changepsiduser();
                }
                if (options == "10")
                {
                    //    saveuserdata(stu1);
                    //    savebooksdata(stu2);
                    //    saveborrowdata(stu);
                    ConsoleUtility.clear();
                    Environment.Exit(0);
                }
                if (options == "9")
                {
                    t = false;
                }
            }
            ConsoleUtility.clear();
        }
        public static void printuserList(MUserBL stu1)
        {
            Console.WriteLine("   " + stu1.getname() + "           " + stu1.getpassword());
        }
        public static void removeuser()
        {
            Console.Clear();
            ConsoleUtility.header();
            string rmuser;
            Console.WriteLine("Remove User....");
            Console.WriteLine();
            bool t = MUserDL.USERLIST();
            if (t == true)
            {
                Console.Write("Enter name of user to remove: ");
                rmuser = Console.ReadLine();
                bool n = MUserDL.checkremoveuser(rmuser);
                if (n == true)
                {
                    Console.WriteLine("User has been removed sucessfully.............");
                    //saveuserdata(stu1);

                }
                else if (n == true)
                {
                    Console.WriteLine("User not found. << or >> Enter Correct Name.");
                }
            }
            if (t == false)
            {
                Console.WriteLine("No user existed.");
            }
            ConsoleUtility.clear();
            ConsoleUtility.header();
        }
        public static void changeadminpas()
        {
            Console.Clear();
            ConsoleUtility.header();
            string c = "a", d = "a", e, f;
            Console.WriteLine("Change Admin id and Password....");
            Console.WriteLine();
            Console.Write("Enter old admin name: ");
            e = Console.ReadLine();
            Console.Write("Enter old admin password: ");
            f = Console.ReadLine();
            bool t = MUserDL.CheckAdmin(ref e, ref f);
            if (t == true)
            {
                while (d.Length < 8)
                {
                    Console.Write("Enter new admin name: ");
                    c = Console.ReadLine();
                    Console.Write("Enter new admin password: ");
                    d = Console.ReadLine();


                    if (d.Length < 8)
                    {
                        Console.WriteLine("Password Should be 8 Characters long.");
                        ConsoleUtility.clear();
                    }
                }
                if (d.Length >= 8)
                {
                    bool n = MUserDL.check(ref c, ref d);
                    if (n == false)
                    {
                        Console.WriteLine("ID and Password Already existed......");
                        Console.ReadKey();
                    }
                    if (n == true)
                    {
                        Console.WriteLine("Id and Password has been changed..........");
                        MUserDL.stu1[0].setname(c);
                        MUserDL.stu1[0].setpassword(d);
                        //saveuserdata(stu1);
                    }
                }
            }
            if (t == false)
            {
                Console.WriteLine("Enter correct old Id and password.........");
            }
            ConsoleUtility.clear();
            ConsoleUtility.header();
        }
        public static void changepsiduser()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("Change User Id and Password....");
            Console.WriteLine();
            string w, x, y, z = "";

            bool t = MUserDL.USERLIST();
            if (t == true)
            {
                Console.Write("Enter Name(Id):");
                x = Console.ReadLine();
                Console.Write("Enter Password:");
                y = Console.ReadLine();
                bool s = librarydl.check(x);
                if (s == true)
                {
                    MUserDL.Changeuseridpassword(x, y);
                }
                else
                {
                    Console.WriteLine("User Has books to retrun. You cant change his/her ID");
                }
            }
            if (t == false)
            {
                Console.WriteLine("No user Existed........");
            }
            ConsoleUtility.clear();
            ConsoleUtility.header();
        }
        public static MUserBL changepassinput()
        {
            MUserBL s = new MUserBL();
            Console.Write("Enter New ID:");
            s.setname(Console.ReadLine());
            Console.Write("Enter New password:");
            s.setpassword(Console.ReadLine());

            return s;
        }
        public static void credential()
        {
            Console.WriteLine("Enter Correct Credentials.....");
        }
        public static void idpasserror()
        {
            Console.WriteLine("Id password has been taken......");
        }
        public static void updatemsg()
        {
            Console.WriteLine("ID and Password has been updated.........");
        }
        public static void passerror()
        {
            Console.WriteLine("Password Should be 8 Characters long.");
        }
        public static void viewfine()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("     View Fine ");
            Console.WriteLine();
            Console.WriteLine("-----------------------.");
            Console.WriteLine();
            bool t = false;
            t = librarydl.printfine();
            if (t == false)
            {
                Console.WriteLine("No book Has been borrowed..............");
            }

            ConsoleUtility.clear();
            ConsoleUtility.header();
        }
        public static void userrpasswrd()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("Change User Id and Password....");
            Console.WriteLine();
            string w, x, y, z = "";

            bool t = MUserDL.USERLIST();
            if (t == true)
            {
                Console.Write("Enter Name(Id):");
                x = Console.ReadLine();
                Console.Write("Enter Password:");
                y = Console.ReadLine();
                bool s = librarydl.check(x);
                if (s == true)
                {
                    MUserDL.Changeuseridpassword(x, y);
                }
                else
                {
                    Console.WriteLine("User Has books to retrun. You cant change his/her ID");
                }
            }
            if (t == false)
            {
                Console.WriteLine("No user Existed........");
            }
            ConsoleUtility.clear();
            ConsoleUtility.header();
        }
        public static void Borrowedbook()
        {
            // saveuserdata();
            // savebooksdata();
            // saveborrowdata();
            Console.Clear();
            ConsoleUtility.header();
            string bnm;
            bool tas = false;
            int y = 0;
            Console.WriteLine("List Borrowed Books....");
            Console.WriteLine();
            bool check = librarydl.Borrowhis();
            if (check == false)
            {
                Console.WriteLine("No books borrowed");
            }
            else
            {
                tas = librarydl.Borrowed();
                if (tas == false)
                {
                    Console.WriteLine("No books are borrowed yet...........");
                }
            }
            ConsoleUtility.clear();
            ConsoleUtility.header();
        }

        public static void search()
        {
            Console.Clear();
            ConsoleUtility.header();
            string seebknm;
            Console.WriteLine("Search Bar....");
            Console.WriteLine();
            bool t = bookdl.Booklist();
            if (t == true)
            {
                Console.Write("Enter name exact name of book to search:");
                seebknm = Console.ReadLine();
                bool ft = false;
                bool ra = false;
                if (ft == true)
                {
                    Console.WriteLine("Book is not available......");
                }
                if (ft == false)
                {
                    ra = bookdl.Printsearch(seebknm);
                    if (ra == false)
                    {
                        Console.WriteLine("Enter correct name.....");
                    }
                }
            }
            if (t == false)
            {
                Console.WriteLine("Sorry no book is available uptill now............. :( ");
            }
            ConsoleUtility.clear();
            ConsoleUtility.header();
        }

    }
}
