using LibraryofLMS.DL.FH;
using LibraryofLMS.Utilities;
using LibraryofLMS.Interfaces;
using LibraryofLMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LibraryofLMS.DL.DB
{
    public class StudentDL_DB: IStudent
    {
        public static List<StudentBL> Students = new List<StudentBL>();
        private Utility db = Utility.GetInstance();
        private static StudentDL_DB StudentDL_DBInstance;

        private StudentDL_DB(string connectionstring)
        {
            LoadStudents();
        }
        public static StudentDL_DB GetStudentDL_DBInstance(string connectionstring)
        {
            if (StudentDL_DBInstance == null)
            {
                StudentDL_DBInstance = new StudentDL_DB(connectionstring);
            }
            return StudentDL_DBInstance;
        }

        public void AddStudents(StudentBL student)
        {
            Students.Add(student);
            StoreStudents(student);
        }
        public bool IsStudentExist(string name, string password)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].getname() == name && Students[i].getpassword() == password)
                {
                    return true;
                }
            }
            return false;
        }
        public int FindStudent(string name, string password)
        {
            int studentNo = 10000;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].getname() == name && Students[i].getpassword() == password)
                {
                    studentNo = i;
                    return studentNo;
                }
            }
            return studentNo;
        }
        public bool CheckValidStudentName(string name)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].getname() == name)
                {
                    return false;
                }
            }
            return true;
        }
        public void LoadStudents()
        {
            string name, password, role;
            string searchquery = "Select * From Student";
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name = dt.Rows[i]["StudentName"].ToString();
                password = dt.Rows[i]["StudentPassword"].ToString();
                role = dt.Rows[i]["Role"].ToString();
                StudentBL st = new StudentBL(name, password);

                Students.Add(st);
            }
        }
        public void StoreStudents(StudentBL student)
        {
            string query = string.Format("INSERT INTO Student(StudentName,StudentPassword,Role)" + "Values ('{0}','{1}','{2}')", student.getname(), student.getpassword(), student.getrole());
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
        public List<StudentBL> GetAllStudents()
        {
            return Students;
        }
        public StudentBL getstudentwithUsername(string username)
        {
            foreach(StudentBL student in Students)
            {
                if (student.getname().Equals(username)) return student;
            }
            return null;
        }

        public void ClearField()
        {
            Students.Clear();
        }

    }
}
