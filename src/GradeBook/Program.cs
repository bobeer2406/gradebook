using System;
using System.Collections.Generic;

namespace GradeBook
{
     class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Piotr's Grade Book");
            book.GradeAdded += OnGradeAdded;

            NewMethod(book);

            var stats = book.GetStatistics();

            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book name {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low:N2}");
            Console.WriteLine($"The highest grade is {stats.High:N2}");
            Console.WriteLine($"The average grade us  {stats.Average:N2} ");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void NewMethod(Book book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("Thank You for a grade");
                }


            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
