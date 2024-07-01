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

namespace LibraryManagementSystemWindowsFormsApp.Forms
{
    public partial class UpdateBook : Form
    {
        public UpdateBook()
        {
            InitializeComponent();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            string idText = idBox.Text.Trim();
            string choice = ChoicecomboBox.Text;
            string bookname = BookNameBox.Text;
            string author = AuthorBox.Text;
            string date = dateTimePicker1.Text;
            if (!string.IsNullOrWhiteSpace(idText))
            {
                if (int.TryParse(idText, out int id))
                {



                    if (!string.IsNullOrWhiteSpace(bookname) &&
                        !string.IsNullOrWhiteSpace(author) &&
                        !string.IsNullOrWhiteSpace(choice) &&
                        !string.IsNullOrWhiteSpace(date))
                    {
                        ObjectHandler.GetBookDL().DeleteBooks(id);

                        BookBL newbook = new BookBL(bookname, author, date, choice);

                        ObjectHandler.GetBookDL().AddBook(newbook);

                        DataTable dt = new DataTable();
                        dt.Columns.Add("BookName");
                        dt.Columns.Add("Author");
                        dt.Columns.Add("PublishDate");
                        dt.Columns.Add("Choice");

                        dt.Rows.Add(newbook.getbooks(), newbook.getauthor(), newbook.getpublishdate(), newbook.getchoice());

                        dataGridView1.DataSource = dt;

                        MessageBox.Show("Updated a book named: " + bookname);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Please fill in all the required fields.");
                    }




                }
                else
                {
                    MessageBox.Show("Please enter a valid integer value for the ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ID cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Clear()
        {
            BookNameBox.Text = "";
            AuthorBox.Text = "";
            dateTimePicker1.Text = "";
            ChoicecomboBox.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.LibrarianForm st = new Forms.LibrarianForm();
            st.Show();

        }
    }
}
