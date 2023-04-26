using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab08
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        public ParttimeStudent(string name) : base(name)
        { }

        public override void RegisterCourses(List<Course> SelectedCourses)
        {
            int TotalCourses = 0;

            foreach (Course course in SelectedCourses)
            {
                TotalCourses += 1;
            }

            if (TotalCourses <= MaxNumOfCourses)
            {
                registeredCourses.Clear();
                registeredCourses = SelectedCourses;
            }
            else
            {
                throw new Exception("PartTimeError");
            }
        }

        public override string ToString()
        {
            return Id.ToString() + " - " + Name + " (Part Time)";
        }
    }
}