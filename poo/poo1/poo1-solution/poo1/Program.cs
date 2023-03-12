using System;
using System.Reflection;

namespace poo1 {
    internal class Program
    {
        public class Book
        {
            public string Title;
            public bool IsRead;

            public Book(string title, bool isread)
            {
                Title = title;
                IsRead = isread;
            }
        }

        public static bool IsReadBook(Book[] books, string titleToSearch)
        {
            foreach (Book book in books)
            {
                if (book.Title == titleToSearch)
                {
                    return book.IsRead;
                }
            }
            return false;
        }

       

        public static void Main(string[] args)
        {
            Book[] books =
            {
                new Book("harry",false),
                new Book("sw",true),
                new Book("zz",true),
                new Book("aa",false),


            };
            Console.WriteLine(IsReadBook(books, "harry"));//false
            Console.WriteLine(IsReadBook(books, "ee"));//false
            Console.WriteLine(IsReadBook(books, "zz"));//true
            Console.WriteLine(IsReadBook(books, "aa"));//false


        }

    }
}