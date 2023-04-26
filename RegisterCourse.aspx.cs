using Lab08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab08
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        public List<string> SelectedItems = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Student> studentList = (List<Student>)Session["StudentList"];
                if (studentList != null)
                {
                    foreach (Student student in studentList)
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = student.ToString();
                        newItem.Value = student.Id.ToString();
                        StudentContainer.Items.Add(newItem);
                    }
                }

                foreach (Course course in Helper.GetAvailableCourses())
                {
                    CheckList.Items.Add(new ListItem(course.Title + " - " + course.WeeklyHours + " hours/week", course.Code));
                }
            }
        }
        //when user select previously registered student show registered info
        protected void DropDownListChange(object sender, EventArgs e)
        {
            RegisterStatus.Visible = false;
            
            CheckList.ClearSelection();

            // if user select studend and there's already saved list do below
            int StudentId = int.Parse(StudentContainer.SelectedValue);

            foreach (Student student in (List<Student>)Session["StudentList"])
            {
                if (student.Id == StudentId)
                {
                    foreach (Course SavedCourse in student.RegisteredCourses)
                    {
                        foreach (ListItem savedItem in CheckList.Items)
                        {
                            if (savedItem.Value == SavedCourse.Code)
                            {
                                savedItem.Selected = true;
                            }
                        }
                    }
                    RegisterStatus.Text = "Selected Student has registered " + student.RegisteredCourses.Count() + " course(s), " + student.TotalWeeklyHours() + " hours weekly";
                    RegisterStatus.Visible = true;
                }
            }
        }

        int totalHours = 0;
        
        protected void submit_Click(object sender, EventArgs e)
        {
            RegisterStatus.Visible = false;
            RegisterError.Visible = false;

            if (StudentContainer.SelectedValue == "-1")
            {
                SelectStudentError.Visible = true ;
                return;
            }

            //store checked classes to spearate list to pass to RegisterCourse();
            List<Course> RegisteredCourseList = new List<Course>();

            // add selected items from CheckBoxes to the list SelectedItems
            foreach (ListItem CheckItem in CheckList.Items)
            {
                
                if (CheckItem.Selected) 
                {
                    SelectedItems.Add(CheckItem.Value);
                    Course selectedCourse = Helper.GetCourseByCode(CheckItem.Value);
                    totalHours += selectedCourse.WeeklyHours;
                    RegisteredCourseList.Add(selectedCourse);
                }
            }

            
            // validate checklist
            int StudentId = int.Parse(StudentContainer.SelectedValue);
           
            foreach (Student student in (List<Student>)Session["StudentList"])
            {
                if (student.Id == StudentId)
                {
                    if (student.GetType() == typeof(FulltimeStudent) && totalHours > FulltimeStudent.MaxWeeklyHours)
                    {
                        RegisterError.Text = "Your selection exceeds the maximum weekly hours: " + FulltimeStudent.MaxWeeklyHours;
                        RegisterError.Visible = true;
                        return;
                    }
                    if (student.GetType() == typeof(ParttimeStudent) && SelectedItems.Count > ParttimeStudent.MaxNumOfCourses)
                    {
                        RegisterError.Text = "Your selection exceeds the maximum number of courses: " + ParttimeStudent.MaxNumOfCourses;
                        RegisterError.Visible = true;
                        return;
                    }
                    if (student.GetType() == typeof(CoopStudent) && totalHours > CoopStudent.MaxWeeklyHours)
                    {
                        RegisterError.Text = "Your selection exceeds the maximum weekly hours: " + CoopStudent.MaxWeeklyHours;
                        RegisterError.Visible = true;
                        return;
                    }
                    if (student.GetType() == typeof(CoopStudent) && SelectedItems.Count > CoopStudent.MaxNumOfCourses)
                    {
                        RegisterError.Text = "Your selection exceeds the maximum number of courses: " + CoopStudent.MaxNumOfCourses;
                        RegisterError.Visible = true;
                        return;
                    }

                    //show summary
                    student.RegisterCourses(RegisteredCourseList);
                    RegisterStatus.Text = "Selected Student has registered " + student.RegisteredCourses.Count() + " course(s), " + student.TotalWeeklyHours() + " hours weekly";
                    RegisterStatus.Visible = true;
                }
            }
        }
    }
}