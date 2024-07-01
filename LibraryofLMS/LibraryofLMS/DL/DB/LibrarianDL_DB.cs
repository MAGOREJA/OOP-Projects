using LibraryofLMS.BL;
using LibraryofLMS.Interfaces;
using LibraryofLMS.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.DL.DB
{
    public class LibrarianDL_DB: ILibrarian
    {
        public static List<LibrarianBL> Librarians = new List<LibrarianBL>();
        private Utility db = Utility.GetInstance();
        private static LibrarianDL_DB LibrarianDL_DBInstance;
        private LibrarianDL_DB(string connectionstring)
        {
            LoadLibrarians();

        }
        public static LibrarianDL_DB GetLibrarianDL_DB(string connectionstring)
        {
            if (LibrarianDL_DBInstance == null)
            {
                LibrarianDL_DBInstance=new LibrarianDL_DB(connectionstring);
            }
            return LibrarianDL_DBInstance;
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
            int LibrarianNo = 1000;
            for (int i = 0; i < Librarians.Count; i++)
            {
                if (Librarians[i].getname() == name && Librarians[i].getpassword() == password)
                {
                    LibrarianNo = i;
                    return LibrarianNo;
                }
            }
            return LibrarianNo;
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
            string name, password, role;
            string searchquery = "Select * From Librarian";
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                name = reader.GetString(0);
                password = reader.GetString(1);
                role = reader.GetString(2);
                LibrarianBL a = new LibrarianBL(name, password);
                Librarians.Add(a);
            }
            reader.Close();
        }
        public void StoreLibrarians(LibrarianBL librarian)
        {
            string query = string.Format("INSERT INTO Librarian(LibrarianName,LibrarianPassword,Role)" + "Values ('{0}','{1}','{2}')", librarian.getname(), librarian.getpassword(), librarian.getrole());

            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
        public List<LibrarianBL> GetAllLibrarians()
        {
            return Librarians;
        }

    }
}
