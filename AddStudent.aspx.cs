using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab08
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Student> studentList = (List<Student>)Session["StudentList"];
                if (studentList == null)
                {
                    TableRow error = new TableRow();
                    StudentTable.Rows.Add(error);

                    TableCell errorCell = new TableCell();
                    errorCell.ColumnSpan = 2;
                    errorCell.HorizontalAlign = HorizontalAlign.Center;
                    error.Cells.Add(errorCell);
                    errorCell.Text = "There is no student added yet";
                }
                else
                {

                    foreach (Student student in studentList)
                    {
                        AppendTable(student);
                    }
                }
            }
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            bool TypeSelect = false;
            int Value = 0;
            bool nameCheck = string.IsNullOrEmpty(NameText.Text);

            foreach (ListItem item in TypeContainer.Items)
            {
                if (item.Selected)
                {
                    int.TryParse(item.Value, out Value);
                    {
                        if (Value != -1)
                        {
                            TypeSelect = true;
                            TypeError.Visible = false;
                        }
                        else
                        {

                            TypeSelect = false;
                            TypeError.Visible = true;
                            return;
                        }

                    }
                }

            }
            if (nameCheck == true)
            {
                NameError.Visible = true;
                return;
            }

            if (nameCheck == false && TypeSelect == true)
            {
                NameError.Visible = false;
                Student newStudent = null;
                switch (Value)
                {
                    case 1:
                        newStudent = new FulltimeStudent(NameText.Text);
                        break;
                    case 2:
                        newStudent = new ParttimeStudent(NameText.Text);
                        break;
                    case 3:
                        newStudent = new CoopStudent(NameText.Text);
                        break;
                }

                List<Student> StudentList = (List<Student>)Session["StudentList"];

                if (StudentList == null)
                {
                    StudentList = new List<Student>();
                }

                StudentList.Add(newStudent);
                Session["StudentList"] = StudentList;

                foreach (Student student in StudentList)
                {
                    AppendTable(student);
                }

                NameText.Text = "";
                TypeContainer.SelectedIndex = 0;
            }
        }

        public void AppendTable(Student student)
        {
            TableRow newRow = new TableRow();
            StudentTable.Rows.Add(newRow);

            TableCell cell = new TableCell();
            newRow.Cells.Add(cell);
            cell.Text = student.Id.ToString();

            cell = new TableCell();
            newRow.Cells.Add(cell);
            cell.Text = student.Name;
        }
    }
}