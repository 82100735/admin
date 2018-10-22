using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;

public class PublicFunction
{
    //MD5加密
    public static string EncryptWithMD5(string myString)
    {
        byte[] sor = Encoding.UTF8.GetBytes(myString);
        MD5 md5 = MD5.Create();
        byte[] result = md5.ComputeHash(sor);
        StringBuilder strbul = new StringBuilder(40);
        for (int i = 0; i < result.Length; i++)
        {
            //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
            strbul.Append(result[i].ToString("x2"));
        }
        return strbul.ToString();
    }

    public static Boolean IsMobileDevice()
    {
        bool isMoblie = false;
        HttpRequest req = System.Web.HttpContext.Current.Request;
        string str_u = req.ServerVariables["HTTP_USER_AGENT"];
        Regex b = new Regex(@"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        if (!(b.IsMatch(str_u) || v.IsMatch(str_u.Substring(0, 4))))
        {
            //PC访问 
            isMoblie = false;
        }
        else
        {
            //手机访问  
            isMoblie = true;
        }
        return isMoblie;
    }

    public static string GenerateRandom(int resultLenth){
        string randomStr = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
        string[] s = randomStr.Split(',');
        string result = "";
        Random random = new Random();
        int maxRandomVal = 62;
        for(int i = 0; i < resultLenth; i++){
            result += s[random.Next(maxRandomVal)].ToString();
        }
        return  result;
    }

    public static string SetColor(string str,string key){
        
        string result = str.Replace(key,"<i style='color:#f00;'>"+key+"</i>");
        
        return  result;
    }

    public static int SetTableInfo(string tableName,string key,string condition){
        int resultRows = -1;

        string strSql = "update "+tableName+" set "+key+" where "+condition+";";

        MySqlConnection conn = PublicFunction.getMySqlCon();
        MySqlCommand  cmd = new MySqlCommand(strSql,conn);

        conn.Open();

        try
        {
            resultRows = cmd.ExecuteNonQuery();
        }
        catch
        {
            conn.Close();
        }

        conn.Close();
        return resultRows;
    }

    public static string GetTableInfo(string tableName,string condition,string key)
    {
        string result = "";
        string strSql = "select * from "+tableName+" where "+condition+";";
        MySqlConnection conn = PublicFunction.getMySqlCon();
        MySqlDataAdapter da = new MySqlDataAdapter(strSql,conn);
        DataTable dt = new DataTable();

        conn.Open();

        try
        {
            da.Fill(dt);
        }
        catch
        {
            conn.Close();
        }
        
        conn.Close();

        if(dt.Rows.Count > 0 && dt != null){
            for(int i = 0; i < dt.Rows.Count; i++){
                result += dt.Rows.Count == 1 ? dt.Rows[0][key].ToString() : dt.Rows[i][key].ToString() + ";";
            }
        }
        return result.ToString();
    }

    public static string UploadImg(){
        string resultMsg = "";
        HttpContext context = HttpContext.Current;
        HttpFileCollection FileCollect = context.Request.Files; //获取文件集合
        string[] imgList = null;;
        List<string> _imgList = new List<string>();
        if(FileCollect.Count > 0){
            string savePath = "/uploadfiles/User/"+DateTime.Now.ToString("yyyyMMdd")+"/"; //存到数据库的相对路径
            string posPath = HttpContext.Current.Server.MapPath(savePath);  //位于服务器的绝对路径
            if (!Directory.Exists(posPath))  //判断目录是否存在
            {   
                Directory.CreateDirectory(posPath); //目录不存在创建目录
            }
            Random rd = new Random();    //生成一个随机对象，必须放在FOR循环外面   否则与FOR循环的性能或者初始化会产生命名冲突
            int maxRandomVal = 777777777;   //设定随机范围
            for (int index = 0; index < FileCollect.Count; index++){
                HttpPostedFile itemFile = context.Request.Files[index];
                if (itemFile.ContentLength < 5120000000000000)
                {
                    if (string.IsNullOrEmpty(itemFile.FileName))
                    {
                        resultMsg = "";
                    }
                    string fex = Path.GetExtension(itemFile.FileName);
                    if(fex == ".jpg" || fex == ".JPG" || fex == ".gif" || fex == ".GIF" || fex == ".png" || fex == ".PNG") //判断文件类型
                    {
                        string fileFullname = itemFile.FileName;  //获取文件名称
                        int randowVal = rd.Next(maxRandomVal);  //产生范围内的随机数
                        string fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + randowVal.ToString();  //重新定义一个新的文件名
                        string fileType = fileFullname.Substring(fileFullname.LastIndexOf("."));   //获取文件后缀
                        string flies = posPath + fileName + fileType;    //生成一个完整的文件名+后缀的字符串
                        itemFile.SaveAs(flies);    //传输的数据流生成重新定义名称的文件并保存
                        string fliePath = savePath + fileName + fileType;  //完整的存储目录+文件名
                        _imgList.Add(fliePath);
                        imgList = _imgList.ToArray();
                        resultMsg = fliePath;
                    }
                    else
                    {
                        resultMsg = "";
                    }
                }
                else
                {
                    resultMsg = "";
                }
            }
        }
        return resultMsg;
    }

    public static object PostRequest(string param,int defaultVal){
        string val = "";
        HttpContext context = HttpContext.Current;
        try
        {
            if(context.Request[param]==null)
            {
                val = defaultVal.ToString();
            }
            else
            {
                val = context.Request[param];
            }
        }
        catch
        {
            val = defaultVal.ToString();
        }
        return val;
    }

    //获取URL参数值
    public static object GetRequest(string param, int defaultVal)
    {
        string val = "";
        try
        {
            if(HttpContext.Current.Request.QueryString[param]==null)
            {
                val = defaultVal.ToString();
            }
            else
            {
                val = HttpContext.Current.Request.QueryString[param];
            }
        }
        catch
        {
            val = defaultVal.ToString();
        }
        return val;
    }

    /// <summary>
    /// 设置默认分类
    /// </summary>
    /// <returns></returns>
    public static string SetDefaultSelected(Repeater repList,string selectedId){
        string selectName = "请选择";
        DataTable dt = (DataTable)repList.DataSource;
        if(dt.Rows.Count > 0 && dt != null){
            for(int i = 0;i < dt.Rows.Count; i++)
            {
               if(dt.Rows[i]["id"].ToString() == selectedId){
                    selectName = dt.Rows[i]["Name"].ToString();
               }
            }
        }
        return selectName;
    }

    /// <summary>
    /// 建立mysql数据库链接
    /// </summary>
    /// <returns></returns>
    public static MySqlConnection getMySqlCon()
    {
        MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString());
        return conn;
    }

    //获取Session
    public static object GetSession(string name)
    {
        return HttpContext.Current.Session[name];
    }

    /// <summary>
    /// 设置Session
    /// </summary>
    /// <param name="pageName">session 名</param>
    /// <param name="pageType">session 值</param>
    /// <returns type="html">pageInfo</returns>
    public static string SetPageInfo(string PageName,int TotalCount,int PageCount,int PageSize,bool Params,int PageType)
    {
        string pageInfo = "";
        string pageName = !string.IsNullOrEmpty(PageName) ? PageName : "index.aspx";
        int totalPage = 0;
        int pageCount = PageCount > 0 && PageCount != null ? PageCount : 10;
        int pageSize = PageSize > 0 && PageSize != null ? PageSize : 1;
        int homePage = 1;
        int prevPage = 1;
        int nextPage = 1;
        int lastPage = 1;
        int pageNumLen = 10;
        int temp = 4;

        totalPage = TotalCount % pageCount == 0 ? TotalCount / pageCount : TotalCount / pageCount + 1;

        pageSize = pageSize < 1 ? 1 : pageSize;

        pageSize = pageSize >= totalPage ? totalPage : pageSize;

        prevPage = (pageSize - 1) < 1 ? 0 : (pageSize - 1);

        nextPage = (pageSize + 1) > totalPage ? totalPage : (pageSize + 1);

        pageInfo = "<span class=\"prev\"><a href='"+(prevPage == 0 ? "javascript:void(0)" : pageName + (Params ? "&" : "?") + "PageSize=" + prevPage.ToString())+"'>上一页</a></span>";

        if(totalPage <= pageNumLen){
            for(int i = 1; i <= totalPage; i++){
                if(i == pageSize){
                    pageInfo += "<span class=\"current\"><a href='"+(pageName + (Params ? "&" : "?") + "PageSize=" + i.ToString())+"'>"+i+"</a></span>";
                }else{
                    pageInfo += "<span><a href='"+(pageName + (Params ? "&" : "?") + "PageSize=" + i.ToString())+"'>"+i+"</a></span>";
                }
            }
        }
        if(totalPage > pageNumLen){
            int j = 1;
            j = (pageSize + temp) <= pageNumLen ? j : (pageSize + temp - pageNumLen) + j;
            j = (j + pageNumLen) <= totalPage ? j : totalPage - pageNumLen;
            for(int i = j; i <= (pageNumLen + j); i++){
                if(i == pageSize){
                    pageInfo += "<span class=\"current\"><a href='"+(pageName + (Params ? "&" : "?") + "PageSize=" + i.ToString())+"'>"+i+"</a></span>";
                }else{
                    pageInfo += "<span><a href='"+(pageName + (Params ? "&" : "?") + "PageSize=" + i.ToString())+"'>"+i+"</a></span>";
                }
            }
        }

        pageInfo += "<span class=\"next\"><a href='"+(pageSize == totalPage ? "javascript:void(0)" : pageName + (Params ? "&" : "?") + "PageSize=" + nextPage.ToString())+"'>下一页</a></span>";

        return pageInfo;
    }

    /// <summary>
    /// 设置Session
    /// </summary>
    /// <param name="name">session 名</param>
    /// <param name="val">session 值</param>
    public static void SetSession(string name, object val)
    {
        HttpContext.Current.Session.Remove(name);
        HttpContext.Current.Session.Add(name, val);
    }


    /// <summary>
    /// 过滤HTML标签
    /// </summary>
    public static string checkStr(string html)
    {
        System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        html = regex1.Replace(html, ""); //过滤<script></script>标记
        html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
        html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
        html = regex4.Replace(html, ""); //过滤iframe
        html = regex5.Replace(html, ""); //过滤frameset
        html = regex6.Replace(html, ""); //过滤frameset
        html = regex7.Replace(html, ""); //过滤frameset
        html = regex8.Replace(html, ""); //过滤frameset
        html = regex9.Replace(html, "");
        html = html.Replace(" ", "");
        html = html.Replace("</strong>", "");
        html = html.Replace("<strong>", "");
        return html;
    }

    /// <summary>
    /// 格式化日期
    /// </summary>
    public static string FormatDateTime(string datetime){
        string times = datetime.Split(' ')[0].Replace("/","-");
        string year = times.Split('-')[0].ToString();
        string month = Convert.ToInt32(times.Split('-')[1].ToString()) < 10 ? "0" + times.Split('-')[1].ToString() : times.Split('-')[1].ToString();
        string day = Convert.ToInt32(times.Split('-')[2].ToString()) < 10 ? "0" + times.Split('-')[2].ToString() : times.Split('-')[2].ToString();
        times = year + "-" + month + "-" + day;
        return times;
    }

    /// <summary>
    /// 日期转为时间戳
    /// </summary>
    public static int GetTimeStamp() 
    { 
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0); 
        return Convert.ToInt32(ts.TotalSeconds); 
    } 

    /// <summary>
    /// 时间戳转为日期
    /// </summary>
    public static DateTime UnTimeStamp(string times)
    {
        long unixTimeStamp = Convert.ToInt32(times);
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
        DateTime dt = startTime.AddSeconds(unixTimeStamp);
        return dt;
    }

    /// <summary>
    /// 截取字数
    /// </summary>
    public static string CutWords(string content,int num)
    {
        string cont = content.Length > num ? content.Substring(0, num) + "......" : content;
        return cont;
    }

    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    /// <summary>
    /// 在图片上增加文字水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_sy">生成的带文字水印的图片路径</param>
    /// <param name="addText">要加的文字</param>
    /// <param name="FontStyle">字体样式</param>
    /// <param name="FontSize">字号大小</param>
    public static void AddWater(string Path, string Path_sy, string addText, string FontFamily, float FontSize)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font(FontFamily, FontSize);
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

        g.DrawString(addText, f, b, 6, 8);
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }
}