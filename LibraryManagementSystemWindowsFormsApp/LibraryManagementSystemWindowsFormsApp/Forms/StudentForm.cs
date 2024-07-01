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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.CredentialsForm credentialsForm = new Forms.CredentialsForm();
            credentialsForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.ViewBooks viewBooksForm = new Forms.ViewBooks();
            viewBooksForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.SearchBookForm search = new Forms.SearchBookForm();
            search.Show();
        }
    }
}
