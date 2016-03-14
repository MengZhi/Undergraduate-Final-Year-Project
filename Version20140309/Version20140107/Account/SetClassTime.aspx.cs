﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class SetClassTime : System.Web.UI.Page
    {
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
            }
        }

        protected void FinishSetting_Click(object sender, EventArgs e)
        {
            //if (CourseDate.Text == "" || TimeStart.Text == "" || TimeEnd.Text == "")
            //{
                Response.Redirect("SetClassForOneLecturer.aspx");
            //}


            //else if (CourseDate.Text != "" && TimeStart.Text != "" && TimeEnd.Text != "")
            //{
            ////insert the course time to database
            //MySqlCommand command = cn.CreateCommand();
            //command.CommandText = "INSERT INTO classinfo (Semester,TeachingYear,BuildingNumber,RoomNumber,LFirstName,LLastName,StaffNumber,CourseCode, CourseName, CourseDate, StartTime, EndTime) "+
            //    "VALUES (@Semester,@TeachingYear,@BuildingNumber,@RoomNumber,@LFirstName,@LLastName,@StaffNumber,@CourseCode, @CourseName, @CourseDate, @StartTime, @EndTime);";
           
            //command.Parameters.AddWithValue("Semester", Semester.Text);
            //command.Parameters.AddWithValue("TeachingYear", TeachingYear.Text);
            //command.Parameters.AddWithValue("BuildingNumber", BuildingNumber.Text);
            //command.Parameters.AddWithValue("RoomNumber", RoomNumber.Text);    
            //command.Parameters.AddWithValue("LFirstName", Session["FirstName"]);
            //command.Parameters.AddWithValue("LLastName", Session["SecondName"]);
            //command.Parameters.AddWithValue("StaffNumber", Session["StaffNumber"]);
            //command.Parameters.AddWithValue("CourseCode", Session["CourseCode"]);
            //command.Parameters.AddWithValue("CourseName", Session["CourseName"]);
            //command.Parameters.AddWithValue("CourseDate", CourseDate.Text);
            //command.Parameters.AddWithValue("StartTime", TimeStart.Text);
            //command.Parameters.AddWithValue("EndTime", TimeEnd.Text);
                       
            //cn.Open();
            //MySqlDataReader rd = command.ExecuteReader();
            //cn.Close();
            //Response.Redirect("SetClassForOneLecturer.aspx");
            //}
        }

        protected void Cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetClassForOneLecturer.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow grdRow = GridView1.Rows[e.RowIndex];

            //string sqlstr = "delete from student where MatricNumber='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            string sqlstr = "delete from classinfo where CourseTimeInfoId='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            

            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();
           
            bind();
        }

        

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Semester = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlSemester")).Text;
            string TeachingYear = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
            string BuildingNumber = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
            string RoomNumber = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
            string CourseDate = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[11].Controls[0])).Text.ToString().Trim();
            string StartTime = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[12].Controls[0])).Text.ToString().Trim();
            string EndTime = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[13].Controls[0])).Text.ToString().Trim();
            string CourseTimeInfoId = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string sqlstr = "update classinfo set Semester=@Semester, TeachingYear=@TeachingYear,BuildingNumber=@BuildingNumber,CourseDate=@CourseDate,StartTime=@StartTime,EndTime=@EndTime where CourseTimeInfoId=@CourseTimeInfoId;";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

            sqlcom.Parameters.Add("@Semester", MySqlDbType.VarChar).Value = Semester;
            sqlcom.Parameters.Add("@TeachingYear", MySqlDbType.VarChar).Value = TeachingYear;
            sqlcom.Parameters.Add("@BuildingNumber", MySqlDbType.VarChar).Value = BuildingNumber;
            sqlcom.Parameters.Add("@RoomNumber", MySqlDbType.VarChar).Value = RoomNumber;
            sqlcom.Parameters.Add("@CourseDate", MySqlDbType.VarChar).Value = CourseDate;
            sqlcom.Parameters.Add("@StartTime", MySqlDbType.VarChar).Value = StartTime;
            sqlcom.Parameters.Add("@EndTime", MySqlDbType.VarChar).Value = EndTime;
            sqlcom.Parameters.Add("@CourseTimeInfoId", MySqlDbType.VarChar).Value = CourseTimeInfoId;

            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[15].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you want to delete the record of course：\"" + (e.Row.FindControl("lblCourseCode") as Label).Text + " " + (e.Row.FindControl("lblCourseName") as Label).Text + "\"?')");
                }
            }

            //}   
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void bind()
        {
            //string sqlstr = "select StudentId,FirstName, MatricNumber from attendance.student;";
            string sqlstr = "select CourseTimeInfoId,LFirstName,LLastName,StaffNumber, Semester,TeachingYear,BuildingNumber,RoomNumber,CourseCode,CourseName,CourseDate,StartTime,EndTime from attendance.classinfo where StaffNumber=@StaffNumber and CourseCode=@CourseCode;";           
            MySqlCommand sqlstrCommand = new MySqlCommand(sqlstr, cn);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstrCommand);
            System.Data.DataSet my = new System.Data.DataSet();

            cn.Open();
            sqlstrCommand.Parameters.AddWithValue("@StaffNumber", Session["StaffNumber"]);
            sqlstrCommand.Parameters.AddWithValue("@CourseCode", Session["CourseCode"]);
            
            myda.Fill(my, "attendance.classinfo");
            GridView1.DataSource = my;
            //GridView1.
            GridView1.DataKeyNames = new string[] { "CourseTimeInfoId" };//主键
            GridView1.DataBind();
            cn.Close();
        }

        protected void Set_Click(object sender, EventArgs e)
        {
            if (CourseDate.Text == "" || TimeStart.Text == "" || TimeEnd.Text == "")
            {
                Set.Attributes.Add("onClick", "javascript:alert('Please complete the information.');");
                
            }


            else if (CourseDate.Text != "" && TimeStart.Text != "" && TimeEnd.Text != "")
            {
                //insert the course time to database
                MySqlCommand command = cn.CreateCommand();
                command.CommandText = "INSERT INTO classinfo (Semester,TeachingYear,BuildingNumber,RoomNumber,LFirstName,LLastName,StaffNumber,CourseCode, CourseName, CourseDate, StartTime, EndTime) " +
                    "VALUES (@Semester,@TeachingYear,@BuildingNumber,@RoomNumber,@LFirstName,@LLastName,@StaffNumber,@CourseCode, @CourseName, @CourseDate, @StartTime, @EndTime);";

                command.Parameters.AddWithValue("Semester", Semester.Text);
                command.Parameters.AddWithValue("TeachingYear", TeachingYear.Text);
                command.Parameters.AddWithValue("BuildingNumber", BuildingNumber.Text);
                command.Parameters.AddWithValue("RoomNumber", RoomNumber.Text);
                command.Parameters.AddWithValue("LFirstName", Session["FirstName"]);
                command.Parameters.AddWithValue("LLastName", Session["SecondName"]);
                command.Parameters.AddWithValue("StaffNumber", Session["StaffNumber"]);
                command.Parameters.AddWithValue("CourseCode", Session["CourseCode"]);
                command.Parameters.AddWithValue("CourseName", Session["CourseName"]);
                command.Parameters.AddWithValue("CourseDate", CourseDate.Text);
                command.Parameters.AddWithValue("StartTime", TimeStart.Text);
                command.Parameters.AddWithValue("EndTime", TimeEnd.Text);

                cn.Open();
                MySqlDataReader rd = command.ExecuteReader();
                cn.Close();
                bind();
                //Response.Redirect("SetClassForOneLecturer.aspx");
            }
        }
    }
}