using LibraryofLMS.BL;
using LibraryofLMS.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.DL.FH
{
    public class LibrarianDL_FH: ILibrarian
    {

        private string filePath = @"D:\\Business\\FileHandling\\Librarians.txt";

        public List<LibrarianBL> Librarians = new List<LibrarianBL>();
        private static LibrarianDL_FH LibrarianDL_FHInstance;

        private LibrarianDL_FH(string filePath)
        {
            LoadLibrarians();
        }

        public static LibrarianDL_FH GetLibrarianDL_FH(string filePath)
        {
            if(LibrarianDL_FHInstance == null)
            {
                LibrarianDL_FHInstance=new LibrarianDL_FH(filePath);
            }
            return LibrarianDL_FHInstance;
        }

        public void AddLibrarian(LibrarianBL librarian)
        {
            Librarians.Add(librarian);
            StoreLibrarians(librarian);
        }

        public bool IsLibrarianExist(string name, string password)
        {
            for (int i = 0; i < Librarians.Count; i++)
            {
                if (Librarians[i].getname() == name && Librarians[i].getpassword() == password)
                {
                    return true;
                }
            }
            return false;
        }

        public int FindLibrarian(string name, string password)
        {
            for (int i = 0; i < Librarians.Count; i++)
            {
                if (Librarians[i].getname() == name && Librarians[i].getpassword() == password)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool CheckValidLibrarianName(string name)
        {
            for (int i = 0; i < Librarians.Count; i++)
            {
                if (Librarians[i].getname() == name)
                {
                    return false;
                }
            }
            return true;
        }

        public void LoadLibrarians()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i += 2)
                {
                    string name = lines[i];
                    string password = lines[i + 1];
                    LibrarianBL librarian = new LibrarianBL(name, password);
                    Librarians.Add(librarian);
                }
            }
        }

        public void StoreLibrarians(LibrarianBL librarian)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(librarian.getname());
                writer.WriteLine(librarian.getpassword());
            }
        }

        public List<LibrarianBL> GetAllLibrarians()
        {
            return Librarians;
        }



    }

    }
