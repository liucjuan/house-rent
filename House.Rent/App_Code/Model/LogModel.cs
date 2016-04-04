using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web;

namespace Model
{
    /// <summary>
    /// LogModel 的摘要说明
    /// </summary>
    public class LogModel
    {
        private int l_id;

        public int L_id
        {
            get { return l_id;}
            set { l_id = value; }
        }

        private int m_id;

        public int M_id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private int pro_id;

        public int Pro_id
        {
            get { return pro_id; }
            set { pro_id = value; }
        }

        private DateTime l_date;

        public DateTime L_date
        {
            get { return l_date;}
            set { l_date = value; }
        }

        private int m_id2;

        public int M_id2
        {
            get { return m_id2;}
            set { m_id2 = value; }
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

        private string pro_add;

        public string Pro_add
        {
            get
            {
                return pro_add;
            }
            set { pro_add=value; }
        }

        private string m_tel;

        public string M_tel
        {
            get { return m_tel;}
            set { m_tel = value; }
        }

        private string m_qq;

        public string M_qq
        {
            get { return m_qq;}
            set { m_qq = value; }
        }

        private string m_add;

        public string M_add
        {
            get { return m_add;}
            set { m_add = value; }
        }
    }
}
