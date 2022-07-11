using System;
using System.Collections.Generic;

namespace Gradebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    // ^^ delegates will go in their own file

    public class InMemoryBook : Book, IBook
    {
        private List<double> grades;

        //public string Name{get; set;}

        public const string CATEGORY = "Science"; 


        public InMemoryBook(string name) : base(name) // base also satisfies the base class
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
        public override void AddGrade(double NewGrade) // This adds a grade when given a double
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


        public override event GradeAddedDelegate GradeAdded; // book.GradeAdded invokes the GradeAddedDelagate

        
        public List<double> GetGrades()
        {
            return this.grades;
        }

        
        public override Statistics GetStatistics()
        {

            var result = new Statistics(); // Creation of a new statistics object to return like a way to package that data
            var LengthOfList = grades.Count;

            for(var index = 0; index < LengthOfList; index ++)
            {
                result.Add(grades[index]);
                
            }

            

            return result;
        }
    }
}