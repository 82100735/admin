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
public class UserPage : BasePage
{
    public UserInfo userInfo;
    public UserPage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    override protected void OnLoad(EventArgs e)
    {
        userInfo = (UserInfo)PublicFunction.GetSession("UserInfo");

        if (userInfo == null)
        {
            this.Response.Redirect("Login.aspx", true);
            return;
        }

        base.OnLoad(e);
    }

    public void GoError()
    {
        this.Response.Redirect("/Error.aspx", true);
    }
}
