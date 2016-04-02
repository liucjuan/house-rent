using System;
using System.Collections.Generic;
using System.Web;

namespace Model
{
    /// <summary>
    /// MemberModel 的摘要说明
    /// </summary>
    public class MemberModel
    {
        private int m_id;

        public int M_id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_name;

        public string M_name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private string m_pwd;

        public string M_pwd
        {
            get { return m_pwd; }
            set { m_pwd = value; }
        }

        private string m_tel;

        public string M_tel
        {
            get { return m_tel;}
            set { m_tel = value; }
        }

        private string m_add;

        public string M_add
        {
            get { return m_add;}
            set { m_add = value; }
        }

        private string m_qq;

        public string M_qq
        {
            get { return m_qq;}
            set { m_qq = value; }
        }
    }

}
