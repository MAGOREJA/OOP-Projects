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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystemWindowsFormsApp.Forms
{
    public partial class SearchBookForm : Form
    {
        public SearchBookForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void searchbutton_Click(object sender, EventArgs e)
        {
            string name = BookNameBox.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {

                if (ObjectHandler.GetBookDL().SearchByName(name) != null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("BookName");
                    dt.Columns.Add("Author");
                    dt.Columns.Add("PublishDate");
                    dt.Columns.Add("Choice");

                    BookBL book = ObjectHandler.GetBookDL().SearchByName(name);
                    dt.Rows.Add(book.getbooks(), book.getauthor(), book.getpublishdate(), book.getchoice());

                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Book not found");
                }

            }
            else
            {
                MessageBox.Show("Enter book name first");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.StudentForm st = new Forms.StudentForm();
            st.Show();

        }

    }
}
