using System;
using System.Collections.Generic;
using System.Web;

namespace Model
{
    /// <summary>
    /// LiuYanModel 的摘要说明
    /// </summary>
    public class LiuYanModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string contents;

        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        private string uid;

        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }
    }
}
