using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoAn.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["ThongKeThongTinSinhVien"].ConnectionString;
        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon); 
        }
    }
}