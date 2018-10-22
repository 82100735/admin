using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Security.Cryptography;

/**
 * 仅供UPOP联机对账文件下载使用
 * */

    public class DemoUtil
    {

        public static string GetPrintResult(string url, Dictionary<string, string> req, Dictionary<string, string> resp)
        {
            string result = "=============<br>\n";
            result = result + "地址：" + url + "<br>\n";
            result = result + "请求：" + System.Web.HttpContext.Current.Server.HtmlEncode(SDKUtil.CreateLinkString(req, false, true, System.Text.Encoding.UTF8)).Replace("\n", "<br>\n") + "<br>\n";
            result = result + "应答：" + System.Web.HttpContext.Current.Server.HtmlEncode(SDKUtil.CreateLinkString(resp, false, false, System.Text.Encoding.UTF8)).Replace("\n", "<br>\n") + "<br>\n";
            result = result + "=============<br>\n";
            return result;
        }
    }
