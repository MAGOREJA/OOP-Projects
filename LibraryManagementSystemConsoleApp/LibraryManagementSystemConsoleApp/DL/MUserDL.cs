using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystemConsoleApp.BL;
using LibraryManagementSystemConsoleApp.UI;

namespace LibraryManagementSystemConsoleApp.DL
{
    class MUserDL
    {
        public static List<MUserBL> stu1 = new List<MUserBL>();
        public static bool signincheck(MUserBL s)
        {
            string options = "";
            bool t = false;
            if (s.getname() == stu1[0].getname() && s.getpassword() == stu1[0].getpassword())
            {
                MUserUI.Adminoptions(options);
                return true;
            }
            for (int x = 1; x < stu1.Count; x++)
            {
                if (s.getname() == stu1[x].getname() && s.getpassword() == stu1[x].getpassword())
                {
                    stu1[x].setindex(x);
                    return true;
                }

            }
            return false;
        }
        public static bool existeduser(string cname)
        {
            bool at = false;
            for (int d = 0; d < stu1.Count; d++)
            {

                if (stu1[d].getname() == cname)
                {
                    at = true;
                    return at;
                }
            }
            return at;
        }
        public static void adduserlist(MUserBL s)
        {
            stu1.Add(s);
        }
        public static bool checkremoveuser(string rmuser)
        {
            for (int i = 1; i <= stu1.Count; i++)
            {
                if (rmuser == stu1[i].getname())
                {
                    stu1.RemoveAt(i);
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public static bool CheckAdmin(ref string e, ref string f)
        {
            if (e == stu1[0].getname() && f == stu1[0].getpassword())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool check(ref string c, ref string d)
        {
            for (int y = 0; y < stu1.Count; y++)
            {
                if (c == stu1[y].getname())
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return true;
        }
        public static bool USERLIST()
        {
            if (stu1.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void PRINTUSERLIST()
        {
            Console.WriteLine("   Username       Password");
            Console.WriteLine();
            for (int x = 1; x < stu1.Count; x++)
            {
                MUserUI.printuserList(stu1[x]);
            }
        }

        public static void Changeuseridpassword(string x, string y)
        {
            for (int i = 1; i < stu1.Count; i++)
            {
                MUserBL s = new MUserBL();
                while (s.getpassword().Length < 8)
                {
                    if (x == stu1[i].getname() && y == stu1[i].getpassword())
                    {
                        s = MUserUI.changepassinput();
                        if (s.getpassword().Length < 8)
                        {
                            MUserUI.passerror();
                            ConsoleUtility.clear();
                        }
                        if (s.getpassword().Length >= 8)
                        {
                            stu1[i].setname(s.getname());
                            stu1[i].setpassword(s.getpassword());
                            MUserUI.updatemsg();
                            //saveuserdata(stu1);
                            break;

                        }
                    }
                    if (i < stu1.Count)
                    {
                        continue;
                    }
                    else if (i >= stu1.Count)
                    {
                        MUserUI.credential();
                        break;
                    }
                }
            }
        }

    }
}
