using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab08
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public FulltimeStudent(string name) : base(name)
        { }

        public override void RegisterCourses(List<Course> SelectedCourses)
        {
            int TotalHours = 0;
           
            foreach (Course course in SelectedCourses)
            {
                TotalHours += course.WeeklyHours;
            }

            if(TotalHours <= MaxWeeklyHours)
            {
                registeredCourses.Clear();
                registeredCourses = SelectedCourses;
            }
            else
            {
                throw new Exception("FullTimeError");
            }
        }

        public override string ToString()
        {
            return Id.ToString() + " - " +  Name + " (Full Time)"; 
        }
    }
}