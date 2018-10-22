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
/// 管理员基页
/// </summary>
public class AdminPage : BasePage
{
    public Admin admin;
    public AdminPage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    override protected void OnLoad(EventArgs e)
    {
        admin = (Admin)PublicFunction.GetSession("Admin");

        if (admin == null)
        {
            this.Response.Redirect("/System/login.aspx", true);
            return;
        }

        base.OnLoad(e);
    }

    public void GoError()
    {
        this.Response.Redirect("/System/error.aspx", true);
    }
}
