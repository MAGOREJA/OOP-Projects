using LibraryofLMS.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsoleApp.UI
{
    public class BooksUI
    {

        public static void addbooks()
        {

            Console.Clear();
            ConsoleUtility.header();
            
            Console.WriteLine("Add Books....");
            Console.WriteLine();
            string choice = bookchoice();
            if (choice != "InValid")
            {

                Console.WriteLine("Enter Book Name:");
                string bookname=Console.ReadLine();
                Console.WriteLine("Enter Author Name");
                string author=Console.ReadLine();
                BookBL book = new BookBL(bookname, author, "Feb24", choice);
                ObjectHandler.GetBookDL().AddBook(book);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            ConsoleUtility.clear();
            ConsoleUtility.header();
        }


        public static void removebook()
        {
            Console.Clear();
            ConsoleUtility.header();
            
            Console.WriteLine("Remove Book....");
            Console.WriteLine();
            Console.WriteLine("Enter id of book to be removed: ");
           
            string str = Console.ReadLine();
            int num;
            bool success = int.TryParse(str, out num);
            if (success)
            {
                ObjectHandler.GetBookDL().DeleteBooks(num);
                Console.WriteLine("Book deleted successfully");
            }
            else
            {
                Console.WriteLine("Give valid id");
            }
        }
        public static void updatebook()
        {
            Console.Clear();
            ConsoleUtility.header();
            
            Console.WriteLine("Update Book....");
            Console.WriteLine();
            Console.WriteLine("Enter id of book to be updated: ");

            string str = Console.ReadLine();
            int num;
            bool success = int.TryParse(str, out num);
            if (success)
            {
                ObjectHandler.GetBookDL().DeleteBooks(num);

                Console.WriteLine("Enter Book Name:");
                string bookname = Console.ReadLine();
                Console.WriteLine("Enter Author Name");
                string author = Console.ReadLine();


                ObjectHandler.GetBookDL().DeleteBooks(num);

                BookBL book = new BookBL(bookname, author, "Feb24", "Fictional");

                Console.WriteLine("Book updated successfully");
            }
            else
            {
                Console.WriteLine("Give valid id");
            }


        }


        public static void booklist()
        {
            Console.Clear();
            ConsoleUtility.header();
            Console.WriteLine("Book List....");
            Console.WriteLine();
            List<BookBL> books =  ObjectHandler.GetBookDL().GetAllBooks();
            foreach(var book in books)
            {
                Console.WriteLine("Bookname\tAuthor\tPublishDte\tChoice");
                Console.WriteLine(book.getbooks()+ "\t" + book.getauthor() + "\t" + book.getpublishdate() + "\t" + book.getchoice());
            }
        }
        public static string bookchoice()
        {
            string choice = booktype1();
            if (choice == "1")
            {
                return "Islamic";
            }
            else if (choice == "2")
            {
                return "Academic";
            }
            else if (choice == "3")
            {
                return "Fictional";
            }
            else if (choice == "4")
            {
                return "Mangas";
            }
            else if (choice == "5")
            {
                return "Romantic";
            }
            else
            {
                return "InValid";
            }
        }


        public static string booktype1()
        {

            Console.WriteLine("Book Category");
            Console.WriteLine("----------------------");
            Console.WriteLine("Select Type of Book to Add......");
            Console.WriteLine("1. Islamic");
            Console.WriteLine("2. Academic");
            Console.WriteLine("3. Fictional");
            Console.WriteLine("4. Mangas");
            Console.WriteLine("5. Romantic");
            Console.WriteLine("Select :");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
