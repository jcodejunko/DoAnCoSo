using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class StudentManager
    {
       
        public string MSSV { get; set; }
        [Required(ErrorMessage ="Nhap vao ma sinh vien")]
        [Display(Name = "Ho")]
        public string Ho { get; set; }
        [Display(Name = "Ten")]
        public string Ten { get; set; }
        [Display(Name = "Lop")]
        public string Lop { get; set; }
        [Display(Name = "Khoa")]
        public string Khoa { get; set; }
        [Display(Name = "sdt")]
        public string SDT { get; set; }

    }
    class StudentList
    {
        DBConnection db;
        public StudentList()
        {
            db = new DBConnection();

        }
        //Lay du lieu sinh vien tu CSDL
        public List<StudentManager>getStudents(string MSSV)
        {
            string sql;
            if (string.IsNullOrEmpty(MSSV))
            {
                sql = "SELECT *FROM Students";
            }
            else
            {
                sql = "SELECT *FROm Students WHERE MSSV = " + MSSV;
            }
            List<StudentManager> strList = new List<StudentManager>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql,con);
            DataTable dt = new DataTable();
            // mo ket noi
            con.Open();
            cmd.Fill(dt);
            // doong ket noi
            cmd.Dispose();
            con.Close();
            StudentManager strStu;
            for(int i = 0; i< dt.Rows.Count;i++)
            {
                strStu = new StudentManager();
                strStu.MSSV = dt.Rows[i]["MSSV"].ToString();
                strStu.Ho = dt.Rows[i]["Ho"].ToString();
                strStu.Ten = dt.Rows[i]["Ten"].ToString();
                strStu.Lop = dt.Rows[i]["Lop"].ToString();
                strStu.Khoa = dt.Rows[i]["Khoa"].ToString();
                strStu.SDT = dt.Rows[i]["SDT"].ToString();
                strList.Add(strStu);
            }
            return strList;
        }
    }
}