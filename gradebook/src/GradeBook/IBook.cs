using System;
using System.Collections.Generic;

namespace Gradebook
{

    public interface IBook //naming convention for C# and .NET to begin with I for interface
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;}
        event GradeAddedDelegate GradeAdded;
    }

}