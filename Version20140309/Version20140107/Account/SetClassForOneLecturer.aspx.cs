﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class SetClassForOneLecturer : System.Web.UI.Page
    {

        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        string varSelectStaffId, varSelectCourseId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
                assignStaffId();
                bind();
                bind2();
            }
            
        }

        public void assignStaffId()
        {


            string SelectStudentId = "select StaffId from staff where StaffNumber=@StaffNumber;";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);
            cn.Open();
            dataCommand1.Parameters.AddWithValue("@StaffNumber", Session["StaffNumber"]);

            varSelectStaffId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            //Response.Write(varSelectStudentId);
        }

        protected void SetTime_Click(object sender, EventArgs e)
        {
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            Session["CourseCode"] = grdRow.Cells[1].Text;
            Session["CourseName"] = grdRow.Cells[2].Text;


            //Session["StaffNumber"] = (grdRow.FindControl("lblStaffNumber") as Label).Text;
            //Response.Write(strField1);
            Response.Redirect("SetClassTime.aspx");

        }

        public void bind()
        {
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn;
            dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@StaffId", varSelectStaffId);

            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn.Open();
            ada.Fill(my);
            GridView1.DataSource = my;
            //GridView1.
            GridView1.DataKeyNames = new string[] { "SRId" };//主键
            GridView1.DataBind();
            cn.Close();

        }

        public void bind2()
        {
            //string sqlstr = "select StudentId,FirstName, MatricNumber from attendance.student;";
            string sqlstr = "select CourseTimeInfoId,LFirstName,LLastName,StaffNumber, Semester,TeachingYear,BuildingNumber,RoomNumber,CourseCode,CourseName,CourseDate,StartTime,EndTime from attendance.classinfo where StaffNumber=@StaffNumber;";
            MySqlCommand sqlstrCommand = new MySqlCommand(sqlstr, cn);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstrCommand);
            System.Data.DataSet my = new System.Data.DataSet();

            cn.Open();
            sqlstrCommand.Parameters.AddWithValue("@StaffNumber", Session["StaffNumber"]);
            myda.Fill(my, "attendance.classinfo");
            GridView2.DataSource = my;
            //GridView1.
            GridView2.DataKeyNames = new string[] { "CourseTimeInfoId" };//主键
            GridView2.DataBind();
            cn.Close();
        }

        protected void FinishSetting_Click(object sender, EventArgs e)
        {
            Session["AuthorizedAdmin"] = "Yes";
            Response.Redirect("SetClass.aspx");
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow grdRow = GridView1.Rows[e.RowIndex];

            //string sqlstr = "delete from student where MatricNumber='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            string sqlstr = "delete from classinfo where CourseTimeInfoId='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'";


            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();

            bind2();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            bind2();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Semester = ((DropDownList)GridView2.Rows[e.RowIndex].FindControl("ddlSemester")).Text;
            string TeachingYear = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
            string BuildingNumber = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
            string RoomNumber = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();            
            string CourseDate = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[11].Controls[0])).Text.ToString().Trim();
            string StartTime = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[12].Controls[0])).Text.ToString().Trim();
            string EndTime = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[13].Controls[0])).Text.ToString().Trim();
            string CourseTimeInfoId = GridView2.DataKeys[e.RowIndex].Value.ToString();

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
            GridView2.EditIndex = -1;
            bind2();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            bind2();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}