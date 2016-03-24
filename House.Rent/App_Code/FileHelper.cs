using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Collections;

namespace CommonLib
{
    public class FileHelper
    {
        #region 上传文件并返回文件所在服务器的相对路径(目录路径+文件的真实名称)
        /// <summary>
        /// 上传文件并返回文件所在服务器的相对路径(目录路径+文件的真实名称)
        /// </summary>
        /// <param name="fileUpload">FileUpload服务器控件</param>
        /// <param name="strPath">文件存放目录</param>
        /// <param name="fileSize">允许上传文件的大小，如userfiles/pro/或../userfiles/pro/</param>
        /// <param name="allowedExtensions">允许上传文件的格式</param>
        /// <param name="mypage">调用方法页面</param>
        /// <returns>返回文件路径(目录路径+文件的真实名称)</returns>
        public static string UploadFile(FileUpload fileUpload, string strPath, int fileSize, string[] allowedExtensions, Page mypage)
        {
            string uploadedPath = "";
            bool fileOk = false;
            string filePath = HttpContext.Current.Server.MapPath(strPath);
            string fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();

            //判断文件后缀名
            if (fileUpload.HasFile)
            {
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i].ToLower())
                    {
                        fileOk = true;
                    }
                }
            }

            if (fileOk)
            {
                try
                {
                    if (fileUpload.PostedFile.ContentLength < fileSize * 1024 * 10)
                    {
                        string filename = Guid.NewGuid().ToString("N");
                        fileUpload.PostedFile.SaveAs(filePath + filename + fileExtension);
                        uploadedPath = strPath + filename + fileExtension;
                    }
                    else
                    {
                        uploadedPath = "";
                        Alert("提示:文件的大小超出规定的大小!", mypage);
                    }
                }
                catch
                {
                    uploadedPath = "";
                }
            }
            else
            {
                uploadedPath = "";
                Alert("提示:你上传的文件格式不正确!", mypage);
            }
            return uploadedPath;
        }
        #endregion

        #region 弹出对话框
        //弹出对话框
        public static void Alert(string strMessage, Page page)
        {
            string key = "";
            string strScript = "<script language=\"javascript\">alert(\"" + strMessage + "\");</script>";
            ClientScriptManager cs = page.ClientScript;
            Type type = page.GetType();
            if (!cs.IsStartupScriptRegistered(key))
            {
                cs.RegisterStartupScript(type, key, strScript);
            }
        }
        #endregion

        #region 把服务器上的文件下载到本地机上
        /// <summary>
        /// 把服务器上的文件下载到本地机上
        /// </summary>
        /// <param name="strDownFile">文件路径</param>
        public static void DownloadFile(string strDownFile, Page mypage)
        {
            string str = HttpContext.Current.Server.MapPath(strDownFile);
            if (System.IO.File.Exists(str))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(str);
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.ClearHeaders();
                System.Web.HttpContext.Current.Response.Buffer = false;
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fi.Name, System.Text.Encoding.UTF8));
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Length", fi.Length.ToString());
                System.Web.HttpContext.Current.Response.WriteFile(fi.FullName);
                System.Web.HttpContext.Current.Response.Flush();
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                Alert("提示:此文件路径不存在!", mypage);
            }
        }
        #endregion

        #region 向页面引入js文件
        /// <summary>
        /// 向页面引入js文件
        /// </summary>
        /// <param name="url">js路径，如/js/js.js</param>
        /// <param name="mypage">需要引入的页面</param>
        public static void AddJS(string url, Page mypage)
        {
            HtmlGenericControl scriptControl = new HtmlGenericControl("script");
            scriptControl.Attributes.Add("type", "text/javascript");
            scriptControl.Attributes.Add("language", "javascript");
            scriptControl.Attributes.Add("src", url);
            mypage.Header.Controls.Add(scriptControl);
        }
        #endregion

        #region 引入js代码
        /// <summary>
        /// 向页面引入js文件
        /// </summary>
        /// <param name="content">js代码</param>
        /// <param name="mypage">需要引入的页面</param>
        public static void AddJS2(string content, Page mypage)
        {
            HtmlGenericControl scriptControl = new HtmlGenericControl("script");
            scriptControl.Attributes.Add("type", "text/javascript");
            scriptControl.Attributes.Add("language", "javascript");
            scriptControl.InnerHtml = content;
            mypage.Header.Controls.Add(scriptControl);
        }
        #endregion

        #region 向页面引入css文件
        /// <summary>
        /// 向页面引入css文件
        /// </summary>
        /// <param name="url">css路径，如/css/css.css</param>
        /// <param name="mypage">需要引入的页面</param>
        public static void AddCSS(string url, Page mypage)
        {
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = url;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            mypage.Header.Controls.Add(cssLink);
        }
        #endregion

        #region 向页面引入网址前面的图标
        /// <summary>
        /// 向页面引入网址前面的图标
        /// </summary>
        /// <param name="url">css路径，如/css/css.css</param>
        /// <param name="mypage">需要引入的页面</param>
        public static void AddICO(string url, Page mypage)
        {
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = url;
            cssLink.Attributes.Add("rel", "shortcut icon");
            cssLink.Attributes.Add("type", "image/x-icon");
            mypage.Header.Controls.Add(cssLink);
        }
        #endregion

        #region 向页面引入Meta
        /// <summary>
        /// 向页面引入Meta
        /// </summary>
        /// <param name="type">meta类型，keywords和description</param>
        /// <param name="content">meta内容</param>
        /// <param name="mypage">需要引入的页面</param>
        public static void AddMeta(string type, string content, Page mypage)
        {
            HtmlGenericControl mymeta = new HtmlGenericControl("meta");
            mymeta.Attributes.Add("name", type);
            mymeta.Attributes.Add("content", content);
            mypage.Header.Controls.Add(mymeta);
        }
        #endregion

        #region 生成静态页面
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="template">模板文件路径，如Server.MapPath("~/test/temp.htm")</param>
        /// <param name="htmlpath">生成静态文件路径，不包含文件名，如Server.MapPath("~/html/")</param>
        /// <param name="arrtemp">需要替换模板的标识，如$title$等</param>
        /// <param name="arrhtml">替换后内容，如$title$替换为生成静态页面</param>
        /// <param name="appoint">是否指定生成静态文件名，为false时，文件名为 时间.html</param>
        /// <param name="filename">指定的静态文件名，如aa.html</param>
        /// <param name="mypage">生成静态文件的页面</param>
        public static void CreateHTML(string template, string htmlpath, ArrayList arrtemp, ArrayList arrhtml, bool appoint, string filename, Page mypage)
        {
            string str = string.Empty;//将模板内容读出来后保存

            if (File.Exists(template))//判断文件是否存在
            {
                Encoding code = Encoding.GetEncoding("gb2312");//编码格式

                StreamReader sr = new StreamReader(template, code);//把文件转换成流

                str = sr.ReadToEnd();//从头读到尾

                sr.Close();//关闭流

                string name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + ".html";//生成静态页面名字

                if (appoint)
                    name = filename;

                //判断生成文件的所在文件夹路径是否存在，不存在则创建
                if (!Directory.Exists(htmlpath))
                {
                    Directory.CreateDirectory(htmlpath);
                }

                try
                {
                    int count = arrtemp.Count >= arrhtml.Count ? arrhtml.Count : arrtemp.Count;

                    //替换里面的内容
                    for (int i = 0; i < count; i++)
                    {
                        str = str.Replace(arrtemp[i].ToString(), arrhtml[i].ToString());
                    }

                    //生成静态页面
                    StreamWriter sw = new StreamWriter(htmlpath + name, false, code);//参数：生成静态文件路径及名称，false表示文件存在则覆盖（true表示文件存在则追加）否则创建文件，编码格式
                    sw.Write(str);
                    sw.Flush();
                    sw.Close();

                    Alert("恭喜，生成成功！", mypage);
                }
                catch
                {
                    Alert("服务器繁忙，生成失败！", mypage);
                }
            }
            else
            {
                Alert("模板路径错误或者已被删除！", mypage);
            }
        }
        #endregion

        #region 生成静态页面
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="template">模板文件路径，如Server.MapPath("~/test/temp.htm")</param>
        /// <param name="htmlpath">生成静态文件路径，不包含文件名，如Server.MapPath("~/html/")</param>
        /// <param name="arrtemp">需要替换模板的标识，如$title$等</param>
        /// <param name="arrhtml">替换后的内容的字段名称</param>
        /// <param name="SqlDataReader">读取数据库后的保存数据的SqlDataReader</param>
        /// <param name="mypage">生成静态文件的页面</param>
        public static void CreateHTML(string template, string htmlpath, ArrayList arrtemp, ArrayList arrhtml, System.Data.SqlClient.SqlDataReader dr, Page mypage)
        {
            string str = string.Empty;//将模板内容读出来后保存

            if (File.Exists(template))//判断文件是否存在
            {
                Encoding code = Encoding.GetEncoding("gb2312");//编码格式

                StreamReader sr = new StreamReader(template, code);//把文件转换成流

                str = sr.ReadToEnd();//从头读到尾

                sr.Close();//关闭流

                //判断生成文件的所在文件夹路径是否存在，不存在则创建
                if (!Directory.Exists(htmlpath))
                {
                    Directory.CreateDirectory(htmlpath);
                }

                int success = 0;//生成文件成功标识
                try
                {
                    int n = 0;
                    while (dr.Read())
                    {
                        string s = str;

                        string name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + n.ToString() + ".html";//生成静态页面名字

                        int count = arrtemp.Count >= arrhtml.Count ? arrhtml.Count : arrtemp.Count;

                        //替换里面的内容
                        for (int i = 0; i < count; i++)
                        {
                            s = s.Replace(arrtemp[i].ToString(), dr[arrhtml[i].ToString()].ToString());
                        }

                        //生成静态页面
                        StreamWriter sw = new StreamWriter(htmlpath + name, false, code);//参数：生成静态文件路径及名称，false表示文件存在则覆盖（true表示文件存在则追加）否则创建文件，编码格式
                        sw.Write(s);
                        sw.Flush();
                        sw.Close();
                        n++;
                        success = 1;
                    }
                }
                catch
                {
                    dr.Close(); dr.Dispose();
                    if (success == 1)
                    {
                        success = 2;
                    }
                }

                if (success == 1)
                {
                    Alert("恭喜，生成成功！", mypage);
                }
                else if (success == 0)
                {
                    Alert("服务器繁忙，生成失败！", mypage);
                }
                else if (success == 2)
                {
                    Alert("服务器繁忙，部分生成失败！", mypage);
                }
            }
            else
            {
                Alert("模板路径错误或者已被删除！", mypage);
            }
        }
        #endregion

        #region 生成静态页面
        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="template">模板文件路径，如Server.MapPath("~/test/temp.htm")</param>
        /// <param name="htmlpath">生成静态文件路径，不包含文件名，如Server.MapPath("~/html/")</param>
        /// <param name="arrtemp">需要替换模板的标识，如$title$等</param>
        /// <param name="arrhtml">替换后的内容的字段名称</param>
        /// <param name="OleDbDataReader">读取数据库后的保存数据的OleDbDataReader</param>
        /// <param name="mypage">生成静态文件的页面</param>
        public static void CreateHTML(string template, string htmlpath, ArrayList arrtemp, ArrayList arrhtml, System.Data.OleDb.OleDbDataReader dr, Page mypage)
        {
            string str = string.Empty;//将模板内容读出来后保存

            if (File.Exists(template))//判断文件是否存在
            {
                Encoding code = Encoding.GetEncoding("gb2312");//编码格式

                StreamReader sr = new StreamReader(template, code);//把文件转换成流

                str = sr.ReadToEnd();//从头读到尾

                sr.Close();//关闭流

                //判断生成文件的所在文件夹路径是否存在，不存在则创建
                if (!Directory.Exists(htmlpath))
                {
                    Directory.CreateDirectory(htmlpath);
                }

                int success = 0;//生成文件成功标识
                try
                {
                    int n = 0;
                    while (dr.Read())
                    {
                        string s = str;

                        string name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + n.ToString() + ".html";//生成静态页面名字

                        int count = arrtemp.Count >= arrhtml.Count ? arrhtml.Count : arrtemp.Count;

                        //替换里面的内容
                        for (int i = 0; i < count; i++)
                        {
                            s = s.Replace(arrtemp[i].ToString(), dr[arrhtml[i].ToString()].ToString());
                        }

                        //生成静态页面
                        StreamWriter sw = new StreamWriter(htmlpath + name, false, code);//参数：生成静态文件路径及名称，false表示文件存在则覆盖（true表示文件存在则追加）否则创建文件，编码格式
                        sw.Write(s);
                        sw.Flush();
                        sw.Close();
                        n++;
                        success = 1;
                    }
                }
                catch
                {
                    dr.Close(); dr.Dispose();
                    if (success == 1)
                    {
                        success = 2;
                    }
                }

                dr.Close(); dr.Dispose();
                if (success == 1)
                {
                    Alert("恭喜，生成成功！", mypage);
                }
                else if (success == 0)
                {
                    Alert("服务器繁忙，生成失败！", mypage);
                }
                else if (success == 2)
                {
                    Alert("服务器繁忙，部分生成失败！", mypage);
                }
            }
            else
            {
                Alert("模板路径错误或者已被删除！", mypage);
            }
        }
        #endregion
    }
}
