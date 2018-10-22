<%@ WebHandler Language="C#" Class="userRegister" %>
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;

public class userRegister : IHttpHandler,System.Web.SessionState.IRequiresSessionState  {


    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        context.Response.AddHeader("Access-Control-Allow-Origin", "*");

        string userId = PublicFunction.PostRequest("userId",-1).ToString();
        string password = PublicFunction.PostRequest("password",-1).ToString();
        string checkCode = PublicFunction.PostRequest("checkCode",-1).ToString();

        object result = null;
        result = userRegisterNow(userId,password,checkCode); 
        context.Response.Write(result);
    }

   
    protected object userRegisterNow(string _userId,string _password,string _checkCode)
    {
        int resultCode = 1;
        string resultMsg = "Error：注册失败！";
        string checkCode = PublicFunction.GetTableInfo("t_checkcode", "name = 'register'","value");

        // try
        // {                                          
        //     checkCode = PublicFunction.GetSession("register").ToString();
        // }
        // catch
        // {
        //     resultMsg = "Error：验证码输入错误！";
        //     resultCode = 1;
        //     checkCode = "";
        // }

        if (_checkCode.ToUpper() != checkCode.ToUpper())
        {
            resultMsg = "Error：验证码输入错误！";
            resultCode = 1;
        }
        else
        {

            string strSql = "insert into t_admin(NavId,username,password,content,smallImageUrl,lastloginip,lastlogintime,isLock,isAdmin,sort)values('7','"+_userId+"','"+PublicFunction.EncryptWithMD5(_password)+"','暂无内容...','','"+ DateTime.Now.ToString() +"','"+ DateTime.Now.ToString() +"','1','1','1')";
        
            MySqlConnection conn = PublicFunction.getMySqlCon();
            MySqlCommand  cmd = new MySqlCommand(strSql,conn);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
                resultMsg = "Success：注册成功！";
                resultCode = 0;
            }
            catch(Exception e)
            {
                resultMsg = "Error：注册失败！原因：" + e.Message;
                resultCode = 1;
            }

            conn.Close();
        }

        object result = new JObject(
                            new JProperty("code",resultCode),
                            new JProperty("msg",resultMsg),
                            new JProperty("data",new JObject(
                                    new JProperty("username",_userId)
                                ))
                        );
        return result;
    }



    public bool IsReusable {
        get {
            return false;
        }
    }

}