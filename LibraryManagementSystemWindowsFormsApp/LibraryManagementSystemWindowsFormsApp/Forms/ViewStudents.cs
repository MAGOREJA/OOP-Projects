using LibraryofLMS.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWindowsFormsApp.Forms
{
    public partial class ViewStudents : Form
    {
        public ViewStudents()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.LibrarianForm st = new Forms.LibrarianForm();
            st.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            printStudents();
            ObjectHandler.GetStudentDL().ClearField();
            ObjectHandler.GetStudentDL().LoadStudents();
        }

        private void printStudents()
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StudentName", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.Columns.Add("Role", typeof(string));
            dataGridView1.DataSource = dataTable;
            List<StudentBL> student = ObjectHandler.GetStudentDL().GetAllStudents();

            if (student != null && student.Count > 0)
            {
                foreach (StudentBL s in student)
                {
                    dataTable.Rows.Add(s.getname(), s.getpassword(), s.getrole());
                }
            }

            dataGridView1.DataSource = dataTable;


        }


    }
}
