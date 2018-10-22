using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Configuration;

/// <summary>
///SendEmail 的摘要说明
/// </summary>
public class SendEmail
{
    private string _to;
    private string _from;
    private string _cc;
    private string _fromname;
    private string _subject;
    private string _content;

    public SendEmail()
    {
        _to = "";
        _from = "";
        _cc = "";
        _fromname = "";
        _subject = "";
        _content = "";
    }
    /// <summary>
    /// 发件人地址
    /// </summary>
    public string From
    {
        get { return _from; }
        set { _from = value; }
    }
    /// <summary>
    /// 收件人
    /// </summary>
    public string To
    {
        get { return _to; }
        set { _to = value; }
    }
    /// <summary>
    /// 抄送
    /// </summary>
    public string CC
    {
        get { return _cc; }
        set { _cc = value; }
    }
    /// <summary>
    /// 发件人姓名
    /// </summary>
    public string FromName
    {
        get { return _fromname; }
        set { _fromname = value; }
    }
    /// <summary>
    /// 邮件标题
    /// </summary>
    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }
    /// <summary>
    /// 邮件内容
    /// </summary>
    public string Content
    {
        get { return _content; }
        set { _content = value; }
    }

    public bool Send()
    {
        //实例化一个MailMessage对象
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
        MailAddress fromAddr = new MailAddress(ConfigurationManager.AppSettings["EmailAcount"].ToString());
        message.From = fromAddr;

        //设置收件人
        // message.To.Add(ConfigurationManager.AppSettings["EmailTo"].ToString());
        message.To.Add(_to);
        /* 可以发送给多人
         * message.To.Add("b@b.com"); 
         * message.To.Add("b@b.com"); 
         * message.To.Add("b@b.com"); 
         */

        //设置抄送人
        //message.CC.Add("qu114.link@gmail.com");
        /* 可以抄送给多人
         * message.CC.Add("c@c.com"); 
         * message.CC.Add("c@c.com"); 
         */

        //设置邮件标题     
        message.Subject = _subject;
        //设置邮件标题编码
        message.SubjectEncoding = System.Text.Encoding.UTF8; 

        //设置邮件内容
        //message.Body = "留言者："+FromName+"！<br/>留言者邮箱："+_from+"！<br/>留言主题："+_subject+"！<br/>网站留言内容："+_content; 
        message.Body = _content;
        //设置邮件内容编码
        message.BodyEncoding = System.Text.Encoding.UTF8;
        //message.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");

        //设置是否是HTML邮件
        message.IsBodyHtml = true; 

        //设置是否添加附件
        // Attachment att = new Attachment(@"C:/Users/Administrator/Desktop/PepsonpuV2.0 (1).pptx");
        // message.Attachments.Add(att);

        //设置邮件优先级
        message.Priority = MailPriority.High; 

        //实例化SMTP发送服务器
        SmtpClient client = new SmtpClient();

        //设置SMTP发送服务器
        client.Host = ConfigurationManager.AppSettings["EmailSMTP"].ToString();

        //设置SMTP发送端口
        client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["EmailPort"].ToString());

        //设置发送人的邮箱账号和密码 和 所属域
        //client.Credentials = new System.Net.NetworkCredential("emailAddress", "password","domain");
        client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailAcount"].ToString(), ConfigurationManager.AppSettings["EmailPassword"].ToString());

        //设置启用ssl,也就是安全发送
        client.EnableSsl = true;

        try
        {
            //发送邮箱
            client.Send(message);
            //Response.Write(@"<script language=JavaScript>alert('您的Email验证邮件已成功发送,请注意查收.');</script>");
            return true;
        }
        catch (Exception e)
        {
            //Response.Write(@"<script language=JavaScript>alert("+e+");</script>");
            return false;
        }

    }

}
