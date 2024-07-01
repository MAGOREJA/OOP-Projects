using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using LibraryManagementSystemWindowsFormsApp.Forms;
using LibraryofLMS.BL;
using LibraryofLMS.DL.DB;

namespace LibraryManagementSystemWindowsFormsApp
{
    public partial class SignIn : Form
    {
        public static bool index;
        public static StudentBL Activestudent;
        public SignIn()
        {
            InitializeComponent();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SignUpbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.SignUp signUp = new Forms.SignUp();
            signUp.Show();
        }

        private void SignInbutton_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;
            string result = "";
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (ObjectHandler.GetStudentDL().IsStudentExist(username, password))
                {
                    index = ObjectHandler.GetStudentDL().IsStudentExist(username, password);
                    result = "Student";
                }
                else if (ObjectHandler.GetLibrarianDL().IsLibrarianExist(username, password))
                {
                    result = "Librarian";
                }
                if (result == "")
                {
                    MessageBox.Show("No Such Person Exist.");
                }
                if (result == "Librarian")
                {
                    this.Hide();
                    LibrarianForm lb = new LibrarianForm();
                    lb.Show();
                }
                else if (result == "Student")
                {
                    Activestudent = ObjectHandler.GetStudentDL().getstudentwithUsername(UsernameBox.Text);
                    this.Hide();
                    StudentForm st = new StudentForm();
                    st.Show();
                }
                else if (result != "")
                {
                    MessageBox.Show($"{username}! successfully Signed In.");
                }
            }
            else
            {
                MessageBox.Show("Please Fill In all the required fields.");
            }
            Clear();



        }
        private void Clear()
        {
            UsernameBox.Text = "";
            PasswordBox.Text = "";
        }

    }
}
