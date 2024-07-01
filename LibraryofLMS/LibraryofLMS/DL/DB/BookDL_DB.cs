using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryofLMS.BL;
using LibraryofLMS.DL.FH;
using LibraryofLMS.Interfaces;
using LibraryofLMS.Utilities;

namespace LibraryofLMS.DL.DB
{
    public class BookDL_DB: IBook
    {
        public static List<BookBL> Book = new List<BookBL>();
        private Utility db = Utility.GetInstance();
        private static BookDL_DB BookDL_DBInstance;

        private BookDL_DB(string connectionstring)
        {

        }
        public static BookDL_DB GetBookDL_DB(string connectionstring)
        {
            if (BookDL_DBInstance == null)
            {
                BookDL_DBInstance = new BookDL_DB(connectionstring);
            }
            return BookDL_DBInstance;
        }
        public void AddBook(BookBL bl)
        {
            Book.Add(bl);
            StoreBooks(bl);
        }


        public static bool Booklist()
        {
            if (Book.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckRemovebook(string rmbknm, string rmauthor)
        {
            for (int i = 0; i < Book.Count; i++)
            {
                if (rmbknm == Book[i].getbooks() && rmauthor == Book[i].getauthor())
                {
                    Book.RemoveAt(i);
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public void LoadBooks()
        {
            string BookName, author, date, choice;
            string searchquery = "Select * From BooksN";
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BookName = dt.Rows[i]["BookName"].ToString();
                author = dt.Rows[i]["Author"].ToString();
                date = dt.Rows[i]["PublishDate"].ToString();
                choice = dt.Rows[i]["Choice"].ToString();
                BookBL bo = new BookBL(BookName, author, date, choice);

                Book.Add(bo);
            }
        }
        public void StoreBooks(BookBL book)
        {
            string query = string.Format("INSERT INTO BooksN(BookName,Author,PublishDate,Choice)" + "Values ('{0}','{1}','{2}', '{3}')", book.getbooks(), book.getauthor(), book.getpublishdate(), book.getchoice());

            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
        public List<BookBL> GetAllBooks()
        {
            return Book;
        }

        public void UpdateBook(string bookname, string author, string date, string choice, int id)
        {
            string query = string.Format("UPDATE BooksN SET BookName='{0}',Author='{1}',PublishDate='{2}', Choice='{3}' WHERE BookID='{4}'", bookname, author, date, choice, id);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
        public void DeleteBooks(int id)
        {
            string query = string.Format("DELETE FROM BooksN WHERE id='{0}'", id);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public BookBL SearchByName(string name)
        {
            BookBL foundBook = null; 
            string query = $"SELECT * FROM BooksN WHERE BookName = '{name}'";
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                foundBook = new BookBL(
                reader["BookName"].ToString(),
                reader["Author"].ToString(),
                reader["PublishDate"].ToString(),
                reader["Choice"].ToString()
            );
            }

            reader.Close();
            return foundBook;
        }

        public void ClearField()
        {
            Book.Clear();
        }

        
        
    }
}
