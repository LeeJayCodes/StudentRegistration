using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab08.Models
{
    public class Course
    {
        public string Code { get; private set; }
        public string Title { get; private set; }
        public int WeeklyHours { get; set; }

        public Course(string CodeInput, string titleInput)
        {
            this.Code = CodeInput;
            this.Title = titleInput;
        }
    }
}