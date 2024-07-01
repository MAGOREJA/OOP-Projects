using LibraryofLMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.Interfaces
{
    public interface ILibrarian
    {
        void AddLibrarian(LibrarianBL librarian);
        bool IsLibrarianExist(string name, string password);
        int FindLibrarian(string name, string password);
        bool CheckValidLibrarianName(string name);
        void LoadLibrarians();
        void StoreLibrarians(LibrarianBL librarian);
        List<LibrarianBL> GetAllLibrarians();
    }
}
