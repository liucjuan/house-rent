using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class verifycode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonLib.VryImgGen gen = new CommonLib.VryImgGen();
            string verifyCode = gen.CreateVerifyCode(5, 1);
            System.Drawing.Bitmap bitmap = gen.CreateImage(verifyCode);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Response.Clear();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.GetBuffer());
            bitmap.Dispose();
            ms.Dispose();
            ms.Close();
            Response.Cookies.Add(new HttpCookie("CheckCode", verifyCode.ToUpper()));//临时会话，客户端无cookies文件
            Response.End();
        }
    }
}
