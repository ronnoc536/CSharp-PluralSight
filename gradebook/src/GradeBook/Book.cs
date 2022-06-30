using System;
using System.Collections.Generic;

namespace Gradebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    // ^^ delegates will go in their own file

    public class Book : NamedObject
    {
        private List<double> grades;

        //public string Name{get; set;}

        public const string CATEGORY = "Science"; 


        public Book(string name) : base(name) // base also satisfies the base class
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter) // This adds a grade when given a letter
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90.0);
                    break;
                case 'B':
                    AddGrade(80.0);
                    break;
                case 'C':
                    AddGrade(70.0);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double NewGrade) // This adds a grade when given a double
        {
            if(NewGrade <= 100 && NewGrade >= 0)
            {
                grades.Add(NewGrade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                //throw new ArgumentException($"Invalid {nameof(NewGrade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded; // book.GradeAdded invokes the GradeAddedDelagate

        
        public List<double> GetGrades()
        {
            return this.grades;
        }

        
        public Statistics GetStatistics()
        {

            var result = new Statistics(); // Creation of a new statistics object to return like a way to package that data
            var LengthOfList = grades.Count;

            result.High = double.MinValue; //the smallest possible value for a double
            result.Low = double.MaxValue; // the biggest possible value for a double
            result.Average = 0.0;

            for(var index = 0; index < LengthOfList; index ++)
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d > 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d > 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d > 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d > 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }
    }
}