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
    public partial class BorrowFineForm : Form
    {
        public BorrowFineForm()
        {
            InitializeComponent();
        }

        private void BorrowFineForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.StudentForm st = new Forms.StudentForm();
            st.Show();
        }

        private void Borrowbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
