using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryofLMS.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystemWindowsFormsApp.Forms
{
    public partial class BooksCRUDForm : Form
    {
        public BooksCRUDForm()
        {
            InitializeComponent();
            ObjectHandler.GetBookDL().ClearField();
            ObjectHandler.GetBookDL().LoadBooks();
        }


        private List<BookBL> books = new List<BookBL>(); 

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            printBooks();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Forms.LibrarianForm st = new Forms.LibrarianForm();
            st.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Addbutton_Click(object sender, EventArgs e)
        {
            string choice= ChoicecomboBox.Text;
            string bookname = BookNameBox.Text;
            string author = AuthorBox.Text;
            string date = dateTimePicker1.Text;

            if (!string.IsNullOrWhiteSpace(bookname) &&
                !string.IsNullOrWhiteSpace(author) &&
                !string.IsNullOrWhiteSpace(choice) &&
                !string.IsNullOrWhiteSpace(date))
            {

                BookBL newbook = new BookBL(bookname, author, date, choice);

                ObjectHandler.GetBookDL().AddBook(newbook);

                MessageBox.Show("Added a book named: " + bookname);
                Clear();
            }
            else
            {
                MessageBox.Show("Please fill in all the required fields.");
            }



        }
        private void Clear()
        {
            BookNameBox.Text = "";
            AuthorBox.Text = "";
            dateTimePicker1.Text = "";
            ChoicecomboBox.Text = "";
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {

//            string name = BookNameBox.Text;
//            string choice = ChoicecomboBox.Text;
//            string author = AuthorBox.Text;
//            string date = dateTimePicker1.Text;
//            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(choice) && !string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(author))
//            {
//
//                if (ObjectHandler.GetBookDL().SearchByName(name) != null)
//                {
//                    BookBL book = ObjectHandler.GetBookDL().SearchByName(name);
//                    if (book != null)
//                    {
//                        book.setbooks(name);
//                        book.setauthor(author);
//                        book.setpublishdate (date);
//                        book.setchoice(choice);
//                        MessageBox.Show("Successfully updated.");
//                        Clear();
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Book not found");
//                }
//
//            }
//            else
//            {
//                MessageBox.Show("Enter book details first");
//            }
//            Clear();
        }
    }
}