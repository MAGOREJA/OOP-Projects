using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string option;
            bool n = true;
            while (n)
            {
                option = ConsoleUtility.mainpage();
                if (option == "2")
                {
                    ConsoleUtility.signup();
                }
                else if (option == "1")
                {
                    ConsoleUtility.signin();
                }
                else if (option == "3")
                {
                    n = false;
                }
            }
            ConsoleUtility.clear();


        }
    }
    
}
