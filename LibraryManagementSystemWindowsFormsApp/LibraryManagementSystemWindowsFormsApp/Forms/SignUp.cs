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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystemWindowsFormsApp.Forms
{
    public partial class SignUp : Form
    {
        string username, password, role, confirmPassword;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn studentForm = new SignIn();
            studentForm.Show();
        }

        public SignUp()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RolecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SignUpbutton_Click(object sender, EventArgs e)
        {
            username = UsernameBox.Text;
            password = PasswordBox.Text;
            confirmPassword = CnfrmPasswordBox.Text;

            try
            {
                if(ObjectHandler.GetLibrarianDL().CheckValidLibrarianName(username) && ObjectHandler.GetStudentDL().CheckValidStudentName(username))
                {
                    if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(confirmPassword) && !string.IsNullOrWhiteSpace(role))
                    {
                        role = RolecomboBox.SelectedItem.ToString();

                        if (password != confirmPassword)
                        {
                            MessageBox.Show("Passwords do not match. Please re-enter passwords.");
                            PasswordBox.Clear();
                            CnfrmPasswordBox.Clear();
                            return;
                        }

                        if (role == "Student")
                        {
                            StudentBL newStudent = new StudentBL(username, password);
                            ObjectHandler.GetStudentDL().AddStudents(newStudent);
                            MessageBox.Show("Signing up as a student with username: " + username + " and password: " + password);
                        }
                        else if (role == "Librarian")
                        {
                            LibrarianBL newLibrarian = new LibrarianBL(username, password);
                            ObjectHandler.GetLibrarianDL().AddLibrarian(newLibrarian);
                            MessageBox.Show("Signing up as a librarian with username: " + username + " and password: " + password);
                        }
                        else
                        {
                            MessageBox.Show("Invalid user type selected.");
                        }
                        Clear();
                    }
                    else
                    {
                        if (password != confirmPassword)
                        {
                            MessageBox.Show("Passwords do not match. Please re-enter passwords.");
                            PasswordBox.Clear();
                            CnfrmPasswordBox.Clear();
                            return;
                        }

                        MessageBox.Show("Please fill in all fields.");
                        return;

                    }
                }
                else
                {
                    MessageBox.Show("Enter valid credentials.");
                }
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Clear()
        {
            UsernameBox.Text = "";
            PasswordBox.Text = "";
            RolecomboBox.SelectedItem = "";
        }
    }

}
