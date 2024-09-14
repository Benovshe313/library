using System.ComponentModel.Design;
using lib_admin.Data;
using lib_admin.Models;

namespace lib_admin
{
    public class AdminPanel
    {
        public bool Login(int libId)
        {
            using (var context = new LibraryContext())
            {
                var librarian = context.Libs.FirstOrDefault(l => l.Id == libId);
                if (librarian != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {librarian.FirstName}{librarian.LastName}!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Librarian not found");
                    return false;
                }
            }
        }

        public void Menu()
        {
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Add a new book");
            Console.WriteLine("3. Update book");
            Console.WriteLine("4. Delete book");
            Console.WriteLine("5. Exit");
        }

        public void ViewBooks()
        {
            using (var context = new LibraryContext())
            {
                var books = context.Books.ToList();

                foreach (var book in books)
                {
                    Console.WriteLine(book.Name);
                }
            }
        }
        public void AddBook()
        {
            using (var context = new LibraryContext())
            {
                var addBook = new Book();

                try
                {
                    Console.WriteLine("Enter book Id: ");
                    addBook.Id = int.Parse(Console.ReadLine());

                    if (context.Books.Any(b => b.Id == addBook.Id))
                    {
                        throw new Exception("ID already exist");
                    }

                    Console.WriteLine("Enter book name: ");
                    addBook.Name = Console.ReadLine();

                    Console.WriteLine("Enter pages: ");
                    addBook.Pages = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter year of press: ");
                    addBook.YearPress = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter themeId: ");
                    addBook.Id_Themes = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter categoryId: ");
                    addBook.Id_Category = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter authorId: ");
                    addBook.Id_Author = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter pressId: ");
                    addBook.Id_Press = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter comment or press Enter to skip: ");
                    addBook.Comment = Console.ReadLine();

                    Console.WriteLine("Enter quantity: ");
                    addBook.Quantity = int.Parse(Console.ReadLine());

                    context.Books.Add(addBook);
                    context.SaveChanges();
                    Console.WriteLine("New book added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
        public void UpdateBook()
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Enter ID of book");
                int bookId = int.Parse(Console.ReadLine());

                var book = context.Books.FirstOrDefault(b => b.Id == bookId);

                if (book == null)
                {
                    Console.WriteLine("Book not found");
                    return;
                }

                Console.WriteLine("Enter new book name");
                var newName = Console.ReadLine();
                book.Name = newName;

                Console.WriteLine("Enter new number of pages");
                var newPages = Console.ReadLine();
                if (int.TryParse(newPages, out int newPages2))
                {
                    book.Pages = newPages2;
                }

                Console.WriteLine("Enter new pressYear");
                var newYear = Console.ReadLine();
                if (int.TryParse(newYear, out int newYear2))
                {
                    book.YearPress = newYear2;
                }

                Console.WriteLine("Enter new themeId");
                var newTheme = Console.ReadLine();
                if (int.TryParse(newTheme, out int newTheme2))
                {
                    book.Id_Themes = newTheme2;
                }

                Console.WriteLine("Enter new categoryId");
                var newCat = Console.ReadLine();
                if (int.TryParse(newCat, out int newCat2))
                {
                    book.Id_Category = newCat2;
                }

                Console.WriteLine("Enter new authorId");
                var newAuthor = Console.ReadLine();
                if (int.TryParse(newAuthor, out int newAuthor2))
                {
                    book.Id_Author = newAuthor2;
                }

                Console.WriteLine("Enter new pressId");
                var newPress = Console.ReadLine();
                if (int.TryParse(newPress, out int newPress2))
                {
                    book.Id_Press = newPress2;
                }

                Console.WriteLine("Enter new comment");
                var newComment = Console.ReadLine();

                book.Comment = newComment;


                Console.WriteLine("Enter new quantity");
                var newQuantity = Console.ReadLine();
                if (int.TryParse(newQuantity, out int newQuantity2))
                {
                    book.Quantity = newQuantity2;
                }

                context.SaveChanges();
                Console.WriteLine("Book updated");
            }


        }
        public void DeleteBook()
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Enter ID of book");
                int bookId = int.Parse(Console.ReadLine());

                var book = context.Books.FirstOrDefault(b => b.Id == bookId);

                if (book == null)
                {
                    Console.WriteLine("Book not found");
                    return;
                }
                context.Books.Remove(book);
                context.SaveChanges();
                Console.WriteLine("Book deleted");
            }


        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter your Id: ");
                int libId = int.Parse(Console.ReadLine());

                AdminPanel adminPanel = new AdminPanel();

                if (adminPanel.Login(libId))
                {
                    bool exit = false;

                    while (!exit)
                    {
                        adminPanel.Menu();
                        Console.WriteLine("Make a choice: ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                adminPanel.ViewBooks();
                                break;
                            case 2:
                                Console.Clear();
                                adminPanel.AddBook();
                                break;
                            case 3:
                                Console.Clear();
                                adminPanel.UpdateBook();
                                break;
                            case 4:
                                Console.Clear();
                                adminPanel.DeleteBook();
                                break;
                            case 5:
                                exit = true;  
                                
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }

                       
                        if (!exit)
                        {
                            Console.WriteLine("Press Enter back to menu");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            }
        }

    }
}
