<%@ WebHandler Language="C#" Class="userLogin" %>
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

public class userLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {

        context.Response.ContentType = "application/json";
        context.Response.AddHeader("Access-Control-Allow-Origin", "*");
        string userId = PublicFunction.PostRequest("userId",-1).ToString();
        string password = PublicFunction.PostRequest("password",-1).ToString();
        object result = null;
        result = userLoginNow(userId,password); 

        context.Response.Write(result);
    }

   
    protected object userLoginNow(string _userId,string _password)
    {
        int resultCode = 3;
        string resultMsg = "Error：登录失败！";
        string token = "";

        if (_userId == "" || _userId == "-1")
        {
            resultMsg = "Error：账号不能为空！";
            resultCode = 1;
        }
        else if (_password == "" || _password == "-1"){
            resultMsg = "Error：密码不能为空！";
            resultCode = 2;
        }
        else
        {
            System.Threading.Thread.Sleep(500);

            try
            {
                Admin admin = new Admin();
                admin.username = _userId;
                admin.password = _password;

                string Return = "";

                int Result = admin.AdminLogin(ref Return);
                if (Result != 0)
                {
                    resultMsg = "Error："+ Return +"";
                    resultCode = Result;
                }
                else
                {
                    PublicFunction.SetSession("Admin", admin);
                    resultMsg = "Success：登录成功！";
                    resultCode = 0;
                    token = PublicFunction.GenerateRandom(64);
                    PublicFunction.SetSession("token", token);// 使用Session
                }
                
            }
            catch(Exception e)
            {
                resultMsg = "Error：登录失败！原因：" + e.Message;
                resultCode = 3;
            }
        }

        object result = new JObject(
                            new JProperty("code",resultCode),
                            new JProperty("msg",resultMsg),
                            new JProperty("data",new JObject(
                                    new JProperty("token",token),
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