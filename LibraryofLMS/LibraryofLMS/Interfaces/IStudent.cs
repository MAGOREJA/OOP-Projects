using LibraryofLMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.Interfaces
{
    public interface IStudent
    {
        void AddStudents(StudentBL student);
        bool IsStudentExist(string name, string password);
        int FindStudent(string name, string password);
        bool CheckValidStudentName(string name);
        void LoadStudents();
        void StoreStudents(StudentBL student);
        List<StudentBL> GetAllStudents();
        StudentBL getstudentwithUsername(string username);
        void ClearField();
    }
}
