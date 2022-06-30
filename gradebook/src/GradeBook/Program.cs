using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Connor's Grade Book");
            book.GradeAdded += OnGradeAdded;

            Statistics stats;

            EnterGrades(book);

            stats = book.GetStatistics();

            Console.WriteLine(Book.CATEGORY); // not lowercase book because it is a const and not per instance
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The Average grade is {stats.Average:N1}.");
            Console.WriteLine($"The letter grade is {stats.Letter}.");
        }

        private static void EnterGrades(Book book)
        {
            
            while (true)
            {
                Console.WriteLine("Please Enter a Grade or Press 'q' to quit.");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break; // this skips over the parsing so that q is not turned into a double
                }

                else if (input == null)
                {
                    continue; // GOTRIDOF: 'input' may be null here.
                }

                try
                {
                    var grade = double.Parse(input); // input! overides the warning as well
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex) // need to make specific catch statements for particular throws
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine(""); // Good for closing files or network sockets etc.
                }

            };

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("a grade was added");
        }


    }
}

