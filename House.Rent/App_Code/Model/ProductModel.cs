using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Management;

namespace Model
{
    /// <summary>
    /// ProductModel 的摘要说明
    /// </summary>
    public class ProductModel
    {
        public ProductModel()
        {
        }

        private int pro_id;

        public int Pro_id
        {
            get { return pro_id; }
            set { pro_id = value; }
        }

        private string pro_title;

        public string Pro_title
        {
            get { return pro_title; }
            set { pro_title = value; }
        }

        private string pro_name;

        public string Pro_name
        {
            get { return pro_name; }
            set { pro_name = value; }
        }

        private DateTime pro_date;

        public DateTime Pro_date
        {
            get { return pro_date; }
            set { pro_date = value; }
        }

        private string pro_pri;

        public string Pro_pri
        {
            get { return pro_pri; }
            set { pro_pri = value; }
        }


        private string pro_intro;

        public string Pro_intro
        {
            get { return pro_intro; }
            set { pro_intro = value; }
        }

        private int pro_type;

        public int Pro_type
        {
            get { return pro_type; }
            set { pro_type = value; }
        }

        private int pro_num;

        public int Pro_num
        {
            get { return pro_num; }
            set { pro_num = value; }
        }

        private string pro_img;

        public string Pro_img
        {
            get { return pro_img; }
            set { pro_img = value; }
        }

        private int m_id;

        public int M_id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private int pro_cls_id;

        public int Pro_cls_id
        {
            get { return pro_cls_id; }
            set { pro_cls_id = value; }
        }

        private string pro_add;

        public string Pro_add
        {
            get { return pro_add; }
            set { pro_add = value; }
        }

        private string pro_tel;

        public string Pro_tel
        {
            get { return pro_tel; }
            set { pro_tel = value; }
        }

        private string pro_qq;

        public string Pro_qq
        {
            get { return pro_qq; }
            set { pro_qq = value; }
        }

        private string xq;

        public string Xq
        {
            get { return xq; }
            set { xq = value; }
        }

        private string zx;

        public string Zx
        {
            get { return zx; }
            set { zx = value; }
        }

        private string zlc;

        public string Zlc
        {
            get { return zlc; }
            set { zlc = value; }
        }

        private string szlc;

        public string Szlc
        {
            get { return szlc; }
            set { szlc = value; }
        }

        private string cx;

        public string Cx
        {
            get { return cx; }
            set { cx = value; }
        }

        private string ll;

        public string Ll
        {
            get { return ll; }
            set { ll = value; }
        }

        private string yt;

        public string Yt
        {
            get { return yt; }
            set { yt = value; }
        }

        private string states;

        public string States
        {
            get { return states; }
            set { states = value; }
        }
    }
}