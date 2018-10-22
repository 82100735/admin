using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data;
using MySql.Data.MySqlClient;
 

/// <summary>
/// 管理员类
/// </summary>
public class Admin 
{
    public int id;
    public string username;
    public string password;
    public bool isAdmin;
    public string lastloginip;
    public DateTime lastlogintime;

    public Admin()
    {
        id = -1;
        username = "";
        password = "";
        isAdmin = false;
        lastloginip = "";
        lastlogintime = DateTime.Now;
    }

    public int AdminLogin(ref string Return)
    {
        string strSql = "select * from t_admin where username='" + username + "';";
        DataTable dt = new DataTable();
        MySqlConnection conn = PublicFunction.getMySqlCon();
        MySqlDataAdapter da = new MySqlDataAdapter(strSql,conn);
        conn.Open();

        try
        {
            da.Fill(dt);
        }
        catch
        {
            Return = "访问数据库失败";
            return -1;
        }

        if (dt.Rows.Count<=0)
        {
            Return = "用户不存在！";
            return -1;
        }

        if (dt.Rows[0]["isLock"].ToString().Trim() != "1")
        {
            Return = "用户禁止登陆！";
            return -2;
        }

        if (PublicFunction.EncryptWithMD5(password) != dt.Rows[0]["password"].ToString().Trim())
        {
            Return = "密码输入错误！";
            return -3;
        }

        id = int.Parse(dt.Rows[0]["id"].ToString());
        username = dt.Rows[0]["username"].ToString().Trim();
        password = PublicFunction.EncryptWithMD5(password);
        isAdmin = dt.Rows[0]["isAdmin"].ToString() == "0" ? false : true;
        lastloginip = System.Web.HttpContext.Current.Request.UserHostAddress;
        lastlogintime = DateTime.Now;

        //更新登录用户表
        strSql = "update t_admin set lastloginip='" + lastloginip + "',lastlogintime='" + lastlogintime + "' where id=" + id + ";";
        MySqlCommand  cmd = new MySqlCommand(strSql,conn);
        try{
            cmd.ExecuteNonQuery();
        }catch{
            conn.Close();
        }
        conn.Close();

        Return = "";
        return 0;
    }
}
