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
public class UserInfo 
{
    public int id;
    public string username;
    public string password;
    public DateTime lastlogintime;

    public UserInfo()
    {
        id = -1;
        username = "";
        password = "";
        lastlogintime = DateTime.Now;
    }

    public int UserLogin(ref string Return)
    {
        string strSql = "select * from t_member where phone='" + username + "' or email='" + username + "';";
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

        if (PublicFunction.EncryptWithMD5(password) != dt.Rows[0]["password"].ToString().Trim())
        {
            Return = "密码输入错误！";
            return -3;
        }

        id = int.Parse(dt.Rows[0]["id"].ToString());
        // username = dt.Rows[0]["username"].ToString().Trim();
        password = PublicFunction.EncryptWithMD5(password);
        lastlogintime = DateTime.Now;

        //更新登录用户表
        strSql = "update t_member set lastlogintime='" + lastlogintime + "' where id=" + id + ";";
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
