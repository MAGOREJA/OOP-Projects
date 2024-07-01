using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryofLMS.BL;
using LibraryofLMS.DL.FH;
using LibraryofLMS.Interfaces;
using LibraryofLMS.Utilities;


namespace LibraryofLMS.DL.FH
{
    
    namespace LibraryofLMS.DL.FH
    {
        public class BookDL_FH : IBook
        {
            private string filePath = "D:\\Business\\FileHandling\\Books.txt";
            public static List<BookBL> Books = new List<BookBL>();
            private Utility fh = Utility.GetInstance();

            private BookDL_FH(string filePath)
            {
                LoadBooks();
            }

            public static BookDL_FH GetBookDL_FH(string filePath)
            {
                if (BookDL_FHInstance == null)
                {
                    BookDL_FHInstance = new BookDL_FH(filePath);
                }
                return BookDL_FHInstance;
            }

            public void AddBook(BookBL bl)
            {
                Books.Add(bl);
                StoreBooks(bl);
            }

            public static bool Booklist()
            {
                if (Books.Count > 0)
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
                for (int i = 0; i < Books.Count; i++)
                {
                    if (rmbknm == Books[i].getbooks() && rmauthor == Books[i].getauthor())
                    {
                        Books.RemoveAt(i);
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
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i += 4)
                    {
                        string name = lines[i];
                        string author = lines[i + 1];
                        string date = lines[i + 2];
                        string choice = lines[i + 3];
                        BookBL bo = new BookBL(name, author, date, choice);

                        Books.Add(bo);
                    }
                }
            }

            public void StoreBooks(BookBL book)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(book.getbooks());
                    writer.WriteLine(book.getauthor());
                    writer.WriteLine(book.getpublishdate());
                    writer.WriteLine(book.getchoice());
                }
            }

            public List<BookBL> GetAllBooks()
            {
                return Books;
            }

            public void UpdateBook(string bookname, string author, string date, string choice, int id)
            {
                Books[id - 1] = new BookBL(bookname, author, date, choice);
                File.WriteAllLines(filePath, GetAllBooks().Select(x => x.getbooks() + Environment.NewLine + x.getauthor() + Environment.NewLine + x.getpublishdate() + Environment.NewLine + x.getchoice()).ToArray());
            }

            public void DeleteBooks(int id)
            {
                Books.RemoveAt(id - 1);
                File.WriteAllLines(filePath, GetAllBooks().Select(x => x.getbooks() + Environment.NewLine + x.getauthor() + Environment.NewLine + x.getpublishdate() + Environment.NewLine + x.getchoice()).ToArray());
            }
            public BookBL SearchByName(string name)
            {
                BookBL foundBook = null;
                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[i].getbooks() == name)
                    {
                        foundBook = Books[i];
                        break;
                    }
                }
                return foundBook;
            }

            public void ClearField()
            {
                Books.Clear();
                File.WriteAllText(filePath, string.Empty);
            }

            
            private static BookDL_FH BookDL_FHInstance;
        }
    }

}
