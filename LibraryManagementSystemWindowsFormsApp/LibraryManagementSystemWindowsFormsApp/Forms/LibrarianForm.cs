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
    public partial class LibrarianForm : Form
    {
        public LibrarianForm()
        {
            InitializeComponent();
        }

        private void LibrarianForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.BooksCRUDForm booksCRUDForm = new Forms.BooksCRUDForm();
            booksCRUDForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.ViewStudents students = new Forms.ViewStudents();
            students.Show();


        }

        private void SignUpbutton_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.DeleteBook deleteBook = new Forms.DeleteBook();
            deleteBook.Show();

        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.UpdateBook updateBook = new Forms.UpdateBook();
            updateBook.Show();
        }
    }
}
