using LibraryofLMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.Interfaces
{
    public interface IBook
    {

        void AddBook(BookBL bl);
        bool CheckRemovebook(string rmbknm, string rmauthor);
        void LoadBooks();
        void StoreBooks(BookBL book);
        List<BookBL> GetAllBooks();
        void UpdateBook(string bookname, string author, string date, string choice, int id);
        void DeleteBooks(int id);
        BookBL SearchByName(string name);
        void ClearField();
    }
}
