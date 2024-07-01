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
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            printBooks();
            ObjectHandler.GetBookDL().ClearField();
            ObjectHandler.GetBookDL().LoadBooks();
        }


        private void printBooks()
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("BookName", typeof(string));
            dataTable.Columns.Add("Author", typeof(string));
            dataTable.Columns.Add("PublishDate", typeof(string));
            dataTable.Columns.Add("Choice", typeof(string));
            dataGridView1.DataSource = dataTable;
            List<BookBL> book = ObjectHandler.GetBookDL().GetAllBooks();

            if (book != null && book.Count > 0)
            {
                foreach (BookBL s in book)
                {
                    dataTable.Rows.Add(s.getbooks(), s.getauthor(), s.getpublishdate(), s.getchoice());
                }
            }

            dataGridView1.DataSource = dataTable;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.StudentForm st = new Forms.StudentForm();
            st.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
