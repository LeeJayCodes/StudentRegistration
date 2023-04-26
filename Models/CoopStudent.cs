using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab08
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name)
        { }

        public override void RegisterCourses(List<Course> SelectedCourses)
        {
            int TotalCourses = 0;
            int TotalHours = 0;

            foreach (Course course in SelectedCourses)
            {
                TotalCourses += 1;
            }

            if (TotalCourses <= MaxNumOfCourses && TotalHours <= MaxWeeklyHours)
            {
                registeredCourses.Clear();
                registeredCourses = SelectedCourses;
            }
            else
            {
                throw new Exception("Co-opError");
            }
        }

        public override string ToString()
        {
            return Id.ToString() + " - " + Name + " (Co-op)";
        }
    }
}