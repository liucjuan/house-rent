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
        #region �ϴ��ļ��������ļ����ڷ����������·��(Ŀ¼·��+�ļ�����ʵ����)
        /// <summary>
        /// �ϴ��ļ��������ļ����ڷ����������·��(Ŀ¼·��+�ļ�����ʵ����)
        /// </summary>
        /// <param name="fileUpload">FileUpload�������ؼ�</param>
        /// <param name="strPath">�ļ����Ŀ¼</param>
        /// <param name="fileSize">�����ϴ��ļ��Ĵ�С����userfiles/pro/��../userfiles/pro/</param>
        /// <param name="allowedExtensions">�����ϴ��ļ��ĸ�ʽ</param>
        /// <param name="mypage">���÷���ҳ��</param>
        /// <returns>�����ļ�·��(Ŀ¼·��+�ļ�����ʵ����)</returns>
        public static string UploadFile(FileUpload fileUpload, string strPath, int fileSize, string[] allowedExtensions, Page mypage)
        {
            string uploadedPath = "";
            bool fileOk = false;
            string filePath = HttpContext.Current.Server.MapPath(strPath);
            string fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();

            //�ж��ļ���׺��
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
                        Alert("��ʾ:�ļ��Ĵ�С�����涨�Ĵ�С!", mypage);
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
                Alert("��ʾ:���ϴ����ļ���ʽ����ȷ!", mypage);
            }
            return uploadedPath;
        }
        #endregion

        #region �����Ի���
        //�����Ի���
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

        #region �ѷ������ϵ��ļ����ص����ػ���
        /// <summary>
        /// �ѷ������ϵ��ļ����ص����ػ���
        /// </summary>
        /// <param name="strDownFile">�ļ�·��</param>
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
                Alert("��ʾ:���ļ�·��������!", mypage);
            }
        }
        #endregion

        #region ��ҳ������js�ļ�
        /// <summary>
        /// ��ҳ������js�ļ�
        /// </summary>
        /// <param name="url">js·������/js/js.js</param>
        /// <param name="mypage">��Ҫ�����ҳ��</param>
        public static void AddJS(string url, Page mypage)
        {
            HtmlGenericControl scriptControl = new HtmlGenericControl("script");
            scriptControl.Attributes.Add("type", "text/javascript");
            scriptControl.Attributes.Add("language", "javascript");
            scriptControl.Attributes.Add("src", url);
            mypage.Header.Controls.Add(scriptControl);
        }
        #endregion

        #region ����js����
        /// <summary>
        /// ��ҳ������js�ļ�
        /// </summary>
        /// <param name="content">js����</param>
        /// <param name="mypage">��Ҫ�����ҳ��</param>
        public static void AddJS2(string content, Page mypage)
        {
            HtmlGenericControl scriptControl = new HtmlGenericControl("script");
            scriptControl.Attributes.Add("type", "text/javascript");
            scriptControl.Attributes.Add("language", "javascript");
            scriptControl.InnerHtml = content;
            mypage.Header.Controls.Add(scriptControl);
        }
        #endregion

        #region ��ҳ������css�ļ�
        /// <summary>
        /// ��ҳ������css�ļ�
        /// </summary>
        /// <param name="url">css·������/css/css.css</param>
        /// <param name="mypage">��Ҫ�����ҳ��</param>
        public static void AddCSS(string url, Page mypage)
        {
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = url;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            mypage.Header.Controls.Add(cssLink);
        }
        #endregion

        #region ��ҳ��������ַǰ���ͼ��
        /// <summary>
        /// ��ҳ��������ַǰ���ͼ��
        /// </summary>
        /// <param name="url">css·������/css/css.css</param>
        /// <param name="mypage">��Ҫ�����ҳ��</param>
        public static void AddICO(string url, Page mypage)
        {
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = url;
            cssLink.Attributes.Add("rel", "shortcut icon");
            cssLink.Attributes.Add("type", "image/x-icon");
            mypage.Header.Controls.Add(cssLink);
        }
        #endregion

        #region ��ҳ������Meta
        /// <summary>
        /// ��ҳ������Meta
        /// </summary>
        /// <param name="type">meta���ͣ�keywords��description</param>
        /// <param name="content">meta����</param>
        /// <param name="mypage">��Ҫ�����ҳ��</param>
        public static void AddMeta(string type, string content, Page mypage)
        {
            HtmlGenericControl mymeta = new HtmlGenericControl("meta");
            mymeta.Attributes.Add("name", type);
            mymeta.Attributes.Add("content", content);
            mypage.Header.Controls.Add(mymeta);
        }
        #endregion

        #region ���ɾ�̬ҳ��
        /// <summary>
        /// ���ɾ�̬ҳ��
        /// </summary>
        /// <param name="template">ģ���ļ�·������Server.MapPath("~/test/temp.htm")</param>
        /// <param name="htmlpath">���ɾ�̬�ļ�·�����������ļ�������Server.MapPath("~/html/")</param>
        /// <param name="arrtemp">��Ҫ�滻ģ��ı�ʶ����$title$��</param>
        /// <param name="arrhtml">�滻�����ݣ���$title$�滻Ϊ���ɾ�̬ҳ��</param>
        /// <param name="appoint">�Ƿ�ָ�����ɾ�̬�ļ�����Ϊfalseʱ���ļ���Ϊ ʱ��.html</param>
        /// <param name="filename">ָ���ľ�̬�ļ�������aa.html</param>
        /// <param name="mypage">���ɾ�̬�ļ���ҳ��</param>
        public static void CreateHTML(string template, string htmlpath, ArrayList arrtemp, ArrayList arrhtml, bool appoint, string filename, Page mypage)
        {
            string str = string.Empty;//��ģ�����ݶ������󱣴�

            if (File.Exists(template))//�ж��ļ��Ƿ����
            {
                Encoding code = Encoding.GetEncoding("gb2312");//�����ʽ

                StreamReader sr = new StreamReader(template, code);//���ļ�ת������

                str = sr.ReadToEnd();//��ͷ����β

                sr.Close();//�ر���

                string name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + ".html";//���ɾ�̬ҳ������

                if (appoint)
                    name = filename;

                //�ж������ļ��������ļ���·���Ƿ���ڣ��������򴴽�
                if (!Directory.Exists(htmlpath))
                {
                    Directory.CreateDirectory(htmlpath);
                }

                try
                {
                    int count = arrtemp.Count >= arrhtml.Count ? arrhtml.Count : arrtemp.Count;

                    //�滻���������
                    for (int i = 0; i < count; i++)
                    {
                        str = str.Replace(arrtemp[i].ToString(), arrhtml[i].ToString());
                    }

                    //���ɾ�̬ҳ��
                    StreamWriter sw = new StreamWriter(htmlpath + name, false, code);//���������ɾ�̬�ļ�·�������ƣ�false��ʾ�ļ������򸲸ǣ�true��ʾ�ļ�������׷�ӣ����򴴽��ļ��������ʽ
                    sw.Write(str);
                    sw.Flush();
                    sw.Close();

                    Alert("��ϲ�����ɳɹ���", mypage);
                }
                catch
                {
                    Alert("��������æ������ʧ�ܣ�", mypage);
                }
            }
            else
            {
                Alert("ģ��·����������ѱ�ɾ����", mypage);
            }
        }
        #endregion

        #region ���ɾ�̬ҳ��
        /// <summary>
        /// ���ɾ�̬ҳ��
        /// </summary>
        /// <param name="template">ģ���ļ�·������Server.MapPath("~/test/temp.htm")</param>
        /// <param name="htmlpath">���ɾ�̬�ļ�·�����������ļ�������Server.MapPath("~/html/")</param>
        /// <param name="arrtemp">��Ҫ�滻ģ��ı�ʶ����$title$��</param>
        /// <param name="arrhtml">�滻������ݵ��ֶ�����</param>
        /// <param name="SqlDataReader">��ȡ���ݿ��ı������ݵ�SqlDataReader</param>
        /// <param name="mypage">���ɾ�̬�ļ���ҳ��</param>
        public static void CreateHTML(string template, string htmlpath, ArrayList arrtemp, ArrayList arrhtml, System.Data.SqlClient.SqlDataReader dr, Page mypage)
        {
            string str = string.Empty;//��ģ�����ݶ������󱣴�

            if (File.Exists(template))//�ж��ļ��Ƿ����
            {
                Encoding code = Encoding.GetEncoding("gb2312");//�����ʽ

                StreamReader sr = new StreamReader(template, code);//���ļ�ת������

                str = sr.ReadToEnd();//��ͷ����β

                sr.Close();//�ر���

                //�ж������ļ��������ļ���·���Ƿ���ڣ��������򴴽�
                if (!Directory.Exists(htmlpath))
                {
                    Directory.CreateDirectory(htmlpath);
                }

                int success = 0;//�����ļ��ɹ���ʶ
                try
                {
                    int n = 0;
                    while (dr.Read())
                    {
                        string s = str;

                        string name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + n.ToString() + ".html";//���ɾ�̬ҳ������

                        int count = arrtemp.Count >= arrhtml.Count ? arrhtml.Count : arrtemp.Count;

                        //�滻���������
                        for (int i = 0; i < count; i++)
                        {
                            s = s.Replace(arrtemp[i].ToString(), dr[arrhtml[i].ToString()].ToString());
                        }

                        //���ɾ�̬ҳ��
                        StreamWriter sw = new StreamWriter(htmlpath + name, false, code);//���������ɾ�̬�ļ�·�������ƣ�false��ʾ�ļ������򸲸ǣ�true��ʾ�ļ�������׷�ӣ����򴴽��ļ��������ʽ
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
                    Alert("��ϲ�����ɳɹ���", mypage);
                }
                else if (success == 0)
                {
                    Alert("��������æ������ʧ�ܣ�", mypage);
                }
                else if (success == 2)
                {
                    Alert("��������æ����������ʧ�ܣ�", mypage);
                }
            }
            else
            {
                Alert("ģ��·����������ѱ�ɾ����", mypage);
            }
        }
        #endregion

        #region ���ɾ�̬ҳ��
        /// <summary>
        /// ���ɾ�̬ҳ��
        /// </summary>
        /// <param name="template">ģ���ļ�·������Server.MapPath("~/test/temp.htm")</param>
        /// <param name="htmlpath">���ɾ�̬�ļ�·�����������ļ�������Server.MapPath("~/html/")</param>
        /// <param name="arrtemp">��Ҫ�滻ģ��ı�ʶ����$title$��</param>
        /// <param name="arrhtml">�滻������ݵ��ֶ�����</param>
        /// <param name="OleDbDataReader">��ȡ���ݿ��ı������ݵ�OleDbDataReader</param>
        /// <param name="mypage">���ɾ�̬�ļ���ҳ��</param>
        public static void CreateHTML(string template, string htmlpath, ArrayList arrtemp, ArrayList arrhtml, System.Data.OleDb.OleDbDataReader dr, Page mypage)
        {
            string str = string.Empty;//��ģ�����ݶ������󱣴�

            if (File.Exists(template))//�ж��ļ��Ƿ����
            {
                Encoding code = Encoding.GetEncoding("gb2312");//�����ʽ

                StreamReader sr = new StreamReader(template, code);//���ļ�ת������

                str = sr.ReadToEnd();//��ͷ����β

                sr.Close();//�ر���

                //�ж������ļ��������ļ���·���Ƿ���ڣ��������򴴽�
                if (!Directory.Exists(htmlpath))
                {
                    Directory.CreateDirectory(htmlpath);
                }

                int success = 0;//�����ļ��ɹ���ʶ
                try
                {
                    int n = 0;
                    while (dr.Read())
                    {
                        string s = str;

                        string name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + n.ToString() + ".html";//���ɾ�̬ҳ������

                        int count = arrtemp.Count >= arrhtml.Count ? arrhtml.Count : arrtemp.Count;

                        //�滻���������
                        for (int i = 0; i < count; i++)
                        {
                            s = s.Replace(arrtemp[i].ToString(), dr[arrhtml[i].ToString()].ToString());
                        }

                        //���ɾ�̬ҳ��
                        StreamWriter sw = new StreamWriter(htmlpath + name, false, code);//���������ɾ�̬�ļ�·�������ƣ�false��ʾ�ļ������򸲸ǣ�true��ʾ�ļ�������׷�ӣ����򴴽��ļ��������ʽ
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
                    Alert("��ϲ�����ɳɹ���", mypage);
                }
                else if (success == 0)
                {
                    Alert("��������æ������ʧ�ܣ�", mypage);
                }
                else if (success == 2)
                {
                    Alert("��������æ����������ʧ�ܣ�", mypage);
                }
            }
            else
            {
                Alert("ģ��·����������ѱ�ɾ����", mypage);
            }
        }
        #endregion
    }
}
