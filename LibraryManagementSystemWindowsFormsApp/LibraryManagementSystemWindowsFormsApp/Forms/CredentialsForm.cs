using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystemWindowsFormsApp.Forms
{
    public partial class CredentialsForm : Form
    {
        public CredentialsForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.StudentForm st = new Forms.StudentForm();
            st.Show();
        }

        private void BookNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Changebutton_Click(object sender, EventArgs e)
        {
            if (SignIn.Activestudent.getname() != CurrentuserNameBox.Text)
            {
                MessageBox.Show("Username did not match");
                return;
            }
            if (SignIn.Activestudent.getpassword() != currentPasswordBox.Text)
            {
                MessageBox.Show("Password did not match");
                return;

            }
            if (!string.IsNullOrWhiteSpace(CurrentuserNameBox.Text) && !string.IsNullOrWhiteSpace(currentPasswordBox.Text) && !string.IsNullOrWhiteSpace(newUsernameBox.Text) && !string.IsNullOrWhiteSpace(newPasswordBox.Text))
            {
                SignIn.Activestudent.setname(newUsernameBox.Text);
                SignIn.Activestudent.setpassword(newPasswordBox.Text);
                MessageBox.Show("Credentials has been updated.");
                ObjectHandler.GetStudentDL().StoreStudents(SignIn.Activestudent);
                Clear();
            }
            else
            {
                MessageBox.Show("Fill al the boxes");
                return ;
            }

        }
        private void Clear()
        {
            currentPasswordBox.Text = string.Empty;
            CurrentuserNameBox.Text = string.Empty;
            newUsernameBox.Text = string.Empty;
            newPasswordBox.Text = string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
