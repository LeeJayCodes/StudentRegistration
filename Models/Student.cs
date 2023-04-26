using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab08
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }

        protected List<Course> registeredCourses;

        public Student(string name)
        {
            this.Id = new Random().Next(100000, 999999);
            this.Name = name;
            registeredCourses = new List<Course>();
        }

        public List<Course> RegisteredCourses { get { return registeredCourses; } }
        public virtual void RegisterCourses(List<Course> SelectedCourses)
        {
            SelectedCourses.Clear();
            registeredCourses = SelectedCourses;

        }

        public int TotalWeeklyHours()
        {
            int TotalHours = 0;
            
            foreach (Course course in RegisteredCourses)
            {
                TotalHours += course.WeeklyHours;
            }
            return TotalHours;
        }

    }
}